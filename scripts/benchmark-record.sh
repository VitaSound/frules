#!/usr/bin/env bash
# Append one row to output/benchmark/<run-id>/results.jsonl
#
#   ./scripts/benchmark-record.sh --arm cursor_auto_eco --file 007-gcd.fs --verdict PASS --agent-sec 120
#   ./scripts/benchmark-record.sh --arm ollama_local --file 007-gcd.fs --run-ollama
#
# Env: BENCH_RUN_ID, BENCH_GFORTH_TIMEOUT (default 30), BENCH_OLLAMA_TIMEOUT (default 600)

set -euo pipefail
ROOT="$(cd "$(dirname "$0")/.." && pwd)"
cd "$ROOT"

RUN_ID="${BENCH_RUN_ID:-smoke-$(date +%Y%m%d)}"
GFORTH_TO="${BENCH_GFORTH_TIMEOUT:-30}"
OLLAMA_TO="${BENCH_OLLAMA_TIMEOUT:-600}"
OUT_DIR="$ROOT/output/benchmark/$RUN_ID"
OUT_FILE="$OUT_DIR/results.jsonl"

ARM=""
FILE=""
VERDICT=""
AGENT_SEC=""
NOTES=""
RUN_OLLAMA=0

usage() { sed -n '2,6p' "$0"; exit 1; }

while [ $# -gt 0 ]; do
  case "$1" in
    --arm) ARM="$2"; shift 2 ;;
    --file) FILE="$2"; shift 2 ;;
    --verdict) VERDICT="$2"; shift 2 ;;
    --agent-sec) AGENT_SEC="$2"; shift 2 ;;
    --notes) NOTES="$2"; shift 2 ;;
    --run-ollama) RUN_OLLAMA=1; shift ;;
    --run-id) RUN_ID="$2"; shift 2 ;;
    -h|--help) usage ;;
    *) echo "unknown: $1" >&2; exit 1 ;;
  esac
done

[ -n "$ARM" ] && [ -n "$FILE" ] || usage

COG="$(python3 scripts/benchmark_train_order.py --json | python3 -c "
import json, sys
for r in json.load(sys.stdin):
    if r.get('file') == '$FILE':
        print(r.get('cognitive', 99), r.get('taxonomy_block', '?'), sep='\t')
        break
else:
    print('99\t?')
" 2>/dev/null || echo -e "99\t?")"
COGNITIVE="${COG%%$'\t'*}"
TAXONOMY="${COG#*$'\t'}"

GFORTH_LOG=""
GFORTH_SEC=""

record_json() {
  mkdir -p "$OUT_DIR"
  python3 - "$OUT_FILE" <<PY
import json, sys
from datetime import datetime, timezone
rec = {
  "arm": "$ARM",
  "file": "$FILE",
  "cognitive": int("$COGNITIVE"),
  "taxonomy_block": "$TAXONOMY",
  "verdict": "$VERDICT",
  "agent_sec": float("$AGENT_SEC") if "$AGENT_SEC" else None,
  "gforth_sec": float("$GFORTH_SEC") if "$GFORTH_SEC" else None,
  "notes": """$NOTES""",
  "gforth_log_tail": """$GFORTH_LOG"""[-500:],
  "recorded_at": datetime.now(timezone.utc).strftime("%Y-%m-%dT%H:%M:%SZ"),
}
path = sys.argv[1]
with open(path, "a", encoding="utf-8") as f:
    f.write(json.dumps(rec, ensure_ascii=False) + "\n")
print("recorded:", path)
print(json.dumps(rec, ensure_ascii=False, indent=2))
PY
}

if [ "$RUN_OLLAMA" -eq 1 ]; then
  MODEL="${OLLAMA_MODEL:-forth-qwen3b-core}"
  CHALLENGE="$ROOT/tests/challenges/$FILE"
  TMP="$OUT_DIR/${FILE%.fs}.ollama.fs"
  cp "$CHALLENGE" "$TMP"
  HEADER="$(sed -n '1,40p' "$CHALLENGE")"
  START=$SECONDS
  REPLY="$(timeout "$OLLAMA_TO" ollama run "$MODEL" "Solve this Gforth challenge. Output only Forth code between paste markers.\n\n$HEADER" 2>&1)" || {
    VERDICT=TIMEOUT
    AGENT_SEC=$((SECONDS - START))
    NOTES="ollama timeout ${OLLAMA_TO}s model=$MODEL"
    GFORTH_LOG=""
    record_json
    exit 0
  }
  AGENT_SEC=$((SECONDS - START))
  python3 - "$TMP" "$REPLY" <<'PY'
import re, sys
path, reply = sys.argv[1], sys.argv[2]
text = open(path, encoding="utf-8").read()
m = re.search(r"(=== paste your solution ===.*?=== paste your solution ===)", text, re.S)
if not m:
    sys.exit("no paste markers in challenge")
block = m.group(1)
lines = block.splitlines()
if len(lines) < 2:
    sys.exit("bad paste block")
code = reply.strip()
if "```" in code:
    parts = re.findall(r"```(?:forth)?\s*(.*?)```", code, re.S | re.I)
    code = parts[0].strip() if parts else code
inner = lines[1:-1]
new_inner = [code] if code else []
new_block = lines[0] + "\n" + "\n".join(new_inner) + "\n" + lines[-1]
text = text.replace(block, new_block, 1)
open(path, "w", encoding="utf-8").write(text)
PY
  GFORTH_START=$SECONDS
  set +e
  GFORTH_OUT="$(cd "$ROOT/tests/challenges" && timeout "$GFORTH_TO" gforth "../../$TMP" 2>&1)"
  GFORTH_RC=$?
  set -e
  GFORTH_SEC=$((SECONDS - GFORTH_START))
  GFORTH_LOG="$GFORTH_OUT"
  if [ "$GFORTH_RC" -eq 124 ]; then
    VERDICT=HANG
  elif echo "$GFORTH_OUT" | grep -q "TESTS OK"; then
    VERDICT=PASS
  else
    VERDICT=FAIL
  fi
  NOTES="ollama model=$MODEL auto-paste"
  record_json
  exit 0
fi

[ -n "$VERDICT" ] || { echo "need --verdict or --run-ollama" >&2; exit 1; }
record_json
