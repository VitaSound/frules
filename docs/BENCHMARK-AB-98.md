# A/B benchmark: 98 train challenges

Quantitative comparison of three arms on slice **`train_for_sft` (98 files)** from
[`eval-slices.yaml`](../tests/challenges/eval-slices.yaml).

Related: [`CHALLENGE-RUNS.md`](CHALLENGE-RUNS.md) (prompt, deny-list), [`LOCAL-GEMMA-BENCHMARK.md`](LOCAL-GEMMA-BENCHMARK.md) (Ollama setup), [`OLLAMA-FRULES.md`](OLLAMA-FRULES.md) (SYSTEM build).

**Judge:** `gforth` only → `TESTS OK`. Gold in [`data/challenge-solutions/`](../data/challenge-solutions/) is **forbidden** context for the agent (cheating).

---

## Arms

| Arm | ID | Environment | Model |
|-----|-----|-------------|-------|
| **A — baseline** | `cursor_auto_bare` | No `.cursor/rules/frules*`, no MCP hint, minimal prompt | Cursor **Auto** |
| **B — ecosystem** | `cursor_auto_eco` | `./install.sh . gforth` (or `benchmark-env.sh ecosystem`) + [`AGENTS.md`](../AGENTS.md) + MCP `vitasound-forth` + `PATH` (fmix, flint, fcov, fmcp) | Cursor **Auto** |
| **C — local** | `ollama_local` | Ollama + **core** SYSTEM; no Cursor | **`forth-qwen3b-core`** (primary) |
| **C0 — optional** | `ollama_0.5b` | Same as C, negative control | `forth-qwen-core` (0.5B; Track A closure) |

One **fresh chat** per challenge file. Same prompt template for A/B/C — see [Prompt](#prompt).

---

## Model choice (arm C, RTX 4070)

Hardware reference: [`MODEL-TRAINING.md`](MODEL-TRAINING.md) — RTX 4070 Laptop **16 GB** VRAM (12 GB desktop is tighter).

**Use Qwen Coder, not Gemma 4, as primary local arm.**

| Model | VRAM (guide) | frules SYSTEM | Role |
|-------|--------------|---------------|------|
| Qwen2.5-Coder-0.5B + core | ~2–4 GB + ctx | `forth-qwen-core`, `num_ctx 8192` | **C0** — known fail (Track A) |
| **Qwen2.5-Coder-3B** Q4 + core | ~3–5 GB + ctx | core ~25 KB, `num_ctx 8192` | **C primary** |
| Qwen2.5-Coder-7B Q4 | ~10–14 GB | core only; `num_ctx 4096–8192` | **C+** smoke (5 tasks), not full 98 |
| Gemma4:e4b | ~9.6 GB | full rules often OOM with challenge | Not primary |
| Gemma4:e2b | ~8 GB | core ok | Fallback if 3B OOM |

### Setup arm C (once)

```bash
cd /path/to/frules
ollama pull qwen2.5-coder:3b-instruct
bash scripts/build-ollama-system.sh gforth core -o output/frules-ollama-system-core.txt
bash training/write-modelfile-with-rules.sh forth-qwen3b-core qwen2.5-coder:3b-instruct \
  --system output/frules-ollama-system-core.txt --num-ctx 8192
ollama create forth-qwen3b-core -f training/Modelfile.forth-qwen3b-core
ollama run forth-qwen3b-core "Reply OK"
```

Optional C0: [`OLLAMA-FRULES.md`](OLLAMA-FRULES.md) §3 (`forth-qwen-core` on 0.5B).

---

## Timeout protocol

Avoid repeating the May sprint (one BFS ≈ one week).

| Level | Default | Env override | On exceed |
|-------|---------|--------------|-----------|
| Agent wall-clock | **15 min** | `BENCH_AGENT_TIMEOUT` | Stop → `TIMEOUT` |
| gforth verify | **30 s** | `BENCH_GFORTH_TIMEOUT` | `HANG` |
| Ollama API call | **10 min** | `BENCH_OLLAMA_TIMEOUT` | `TIMEOUT` |

**Verdict enum:** `PASS` | `FAIL` | `TIMEOUT` | `HANG` | `INCONCLUSIVE` (no paste / no gforth run).

For Cursor IDE: watch tool output for `TESTS OK`, then **Stop** — do not wait for end of thinking ([`CHALLENGE-RUNS.md`](CHALLENGE-RUNS.md) § Agent timeout protocol).

Checkpoint every **10** tasks; resume from `results.jsonl`.

---

## Run order (cognitive ascending)

```bash
python3 scripts/benchmark_train_order.py              # human table
python3 scripts/benchmark_train_order.py --json     # machine list
python3 scripts/benchmark_train_order.py --markdown # article template rows
```

Source: `cognitive` (0–10) in [`manifest.yaml`](../tests/challenges/manifest.yaml), files from `train_for_sft` in `eval-slices.yaml`.

Summary tiers after full run: **0–3** / **4–6** / **7–10** pass rates per arm.

---

## Environment switching

```bash
./scripts/benchmark-env.sh status      # current mode
./scripts/benchmark-env.sh bare        # arm A
./scripts/benchmark-env.sh ecosystem   # arm B
./scripts/benchmark-env.sh ollama      # arm C (rules off + OLLAMA_MODEL)
./scripts/benchmark-env.sh restore     # undo bare/ollama
```

State file: `output/benchmark/.env-state` (gitignored via `output/`).

Arm B expects `vitasound-forth` in Cursor MCP config and toolchain on `PATH` — see [fmcp README](https://github.com/VitaSound/fmcp/blob/main/README.md).

---

## Prompt

Copy from [`CHALLENGE-RUNS.md`](CHALLENGE-RUNS.md) § Fresh-chat. Replace `NN-name.fs` with the challenge path.

**Deny** (explicit in chat): `data/challenge-solutions/`, `tests/ans/`, `tests/gforth/`, `examples/`, `sources/`.

---

## Results format

Directory: `output/benchmark/<run-id>/`

### `results.jsonl` (one JSON object per line)

```json
{
  "arm": "cursor_auto_eco",
  "file": "007-gcd.fs",
  "cognitive": 3,
  "taxonomy_block": "scalar-math",
  "verdict": "PASS",
  "agent_sec": 142,
  "gforth_sec": 0.4,
  "notes": "",
  "gforth_log_tail": "TESTS OK\n",
  "recorded_at": "2026-06-08T12:00:00Z"
}
```

### Record after manual Cursor run

```bash
./scripts/benchmark-record.sh \
  --arm cursor_auto_eco \
  --file 007-gcd.fs \
  --verdict PASS \
  --agent-sec 142 \
  --notes "fresh chat, Auto"
```

Arm C (semi-automated infer + gforth):

```bash
./scripts/benchmark-record.sh --arm ollama_local --file 007-gcd.fs --run-ollama
```

---

## Cursor CLI / SDK / thinking

| Channel | Auto | Thinking visible | Shell / gforth | Batch 98 |
|---------|------|------------------|------------------|----------|
| **Cursor IDE** | yes (week 2 default) | UI | Shell + MCP | manual, 1 chat/file |
| **Cursor CLI** (`agent`, `--print`) | yes | `stream-json` `thinking` blocks | sandbox shell | semi-CI; [CLI docs](https://cursor.com/docs/cli/using) |
| **Cursor SDK** (`cursor-sdk` / `@cursor/sdk`) | `model="auto"` | `reasoning effort` via `Cursor.models.list()` | inline MCP stdio (fmcp) | best orchestration candidate |

**Limits (document honestly):**

- IDE **Auto unlimited** ≠ CLI quotas or model routing.
- `--model` with thinking suffixes may be ignored; use `/model` interactively or SDK parameters.
- CLI `--print` needs external `timeout` on the process when the agent hangs.
- MCP **fmcp** requires **local** SDK/CLI runtime + `FMCP_HOME` on `PATH`; cloud agents need MCP passed again on each `send`/`resume`.

**Recommendation:** calibrate on 6 seeds ([`CHALLENGE-RUNS.md`](CHALLENGE-RUNS.md) § Recorded run 2026-05-27) → 98 in semi-auto; arm C fully scripted via Ollama API ([`LOCAL-GEMMA-BENCHMARK.md`](LOCAL-GEMMA-BENCHMARK.md) §5).

---

## Pre-purchase: V100 rental smoke (optional)

Before buying a home NVLink V100 rack, run a **cheap** check:

| Step | Action |
|------|--------|
| 1 | Rent **1× V100 32 GB** for **2–4 hours** |
| 2 | Load ecosystem context (feco + frules tree summary or RAG top-k) |
| 3 | One **hard** challenge (`cognitive` ≥ 7), e.g. `072-word-ladder-len.fs` on hold-out or `028-trap-rain.fs` on train |
| 4 | Same task on **Cursor Auto + ecosystem** (arm B) |
| 5 | Compare: context fit, IR/architecture quality, `TESTS OK`, wall-clock |

Record in `output/benchmark/v100-rental-smoke.jsonl`. **Purchase home rack only** if measurable win over arm B — otherwise stay on Cursor Auto + rental for Track B train only.

---

## Smoke checklist (3 × 3)

Before full 98×3:

```bash
# Pick: cognitive ~2, ~4, ~7 from train (see benchmark_train_order.py)
FILES="116-fizzbuzz-count.fs 008-lcm.fs 028-trap-rain.fs"

for arm in bare ecosystem ollama; do
  ./scripts/benchmark-env.sh "$arm"
  ./scripts/benchmark-env.sh status
done

RUN_ID=smoke-$(date +%Y%m%d)
mkdir -p "output/benchmark/$RUN_ID"
# manual Cursor for bare/eco; benchmark-record.sh --run-ollama for ollama
```

---

## Article table template

After run, regenerate markdown rows:

```bash
python3 scripts/benchmark_train_order.py --markdown --results output/benchmark/<run-id>/results.jsonl
```

Paste into [`devto-publish.md`](draft-devto-frules-ru/devto-publish.md) § A/B or update this file § Results.

---

## See also

- [`AI-VS-TOOLS.md`](AI-VS-TOOLS.md) — what LLM vs static tools
- [`BENCHMARK-SIZING.md`](BENCHMARK-SIZING.md) — 151 / 98 / 53 splits
- [`feco` AGENTS](https://github.com/VitaSound/feco/blob/main/AGENTS.md) — MCP workflow
