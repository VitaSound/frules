#!/usr/bin/env bash
# Smoke test for examples/ and tests/.
#
# Layout:
#   examples/gforth/*.fs   load-only checks via gforth
#   examples/ans/*.fs      load-only checks via gforth and pforth (when available)
#   tests/ans/*.fs         assertions; run on gforth and pforth
#   tests/gforth/*.fs      assertions; run on gforth only
#
# A test passes when its stdout contains "TESTS OK" and not "TESTS FAILED".
# pforth emits a benign "INCLUDE error" line after BYE — we ignore it.
set -uo pipefail

cd "$(dirname "$0")"

have_gforth=0; command -v gforth >/dev/null 2>&1 && have_gforth=1
have_pforth=0; command -v pforth >/dev/null 2>&1 && have_pforth=1
(( have_gforth )) || { echo "gforth not found in PATH" >&2; exit 1; }

fail=0

run_engine() {
  local eng="$1" file="$2" mode="$3"      # mode: load | tests
  local dir base out rc
  dir="$(dirname "$file")"
  base="$(basename "$file")"
  case "$eng" in
    gforth)
      if [[ "$mode" == load ]]; then
        out=$(cd "$dir" && timeout 5 gforth "$base" -e bye 2>&1; printf "__rc=%s" "$?")
      else
        out=$(cd "$dir" && timeout 5 gforth "$base" 2>&1; printf "__rc=%s" "$?")
      fi ;;
    pforth)
      if [[ "$mode" == load ]]; then
        out=$(cd "$dir" && timeout 5 bash -c "(cat $(printf %q "$base"); echo bye) | pforth -q" 2>&1; printf "__rc=%s" "$?")
      else
        out=$(cd "$dir" && timeout 5 pforth -q "$base" 2>&1; printf "__rc=%s" "$?")
      fi ;;
  esac
  rc="${out##*__rc=}"; out="${out%__rc=*}"

  if [[ "$mode" == load ]]; then
    if (( rc != 0 )) || grep -E 'warning:|^error|stack underflow|Backtrace' <<<"$out" >/dev/null; then
      echo "FAIL [$eng] $file"
      echo "$out" | sed 's/^/    /'
      fail=1
    else
      echo "ok   [$eng] $file"
    fi
  else
    if grep -q 'TESTS OK' <<<"$out" && ! grep -q 'TESTS FAILED' <<<"$out" \
       && ! grep -q 'Backtrace' <<<"$out"; then
      echo "ok   [$eng] $file"
    else
      echo "FAIL [$eng] $file (rc=$rc)"
      echo "$out" | sed 's/^/    /'
      fail=1
    fi
  fi
}

run_dir() {
  local mode="$1" dir="$2" engines=("${@:3}")
  [ -d "$dir" ] || return 0
  local f base
  for f in "$dir"/*.fs; do
    [ -f "$f" ] || continue
    base="$(basename "$f")"
    [ "$base" = _tester.fs ] && continue
    for eng in "${engines[@]}"; do
      case "$eng" in
        gforth) (( have_gforth )) || { echo "skip [gforth] $f"; continue; } ;;
        pforth) (( have_pforth )) || { echo "skip [pforth] $f"; continue; } ;;
      esac
      run_engine "$eng" "$f" "$mode"
    done
  done
}

if [[ -f tests/lint.sh ]]; then
  bash tests/lint.sh || fail=1
fi

run_dir load  examples/gforth gforth
run_dir load  examples/ans    gforth pforth
run_dir tests tests/ans       gforth pforth
run_dir tests tests/gforth    gforth

exit "$fail"
