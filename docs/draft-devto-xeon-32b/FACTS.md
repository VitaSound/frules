# Facts sheet — Xeon 32B CPU inference experiment

Fill before final publish. Article and chapters reference this file.

## Status

| Field | Value | Status |
|-------|-------|--------|
| Video URL | `TBD` | **pending author** |
| Server OS | `TBD` (likely Linux) | **pending author** |
| llama.cpp command | `TBD` | **pending author** |
| gforth error v1 | `TBD` | **pending author** |
| gforth error v2 | `TBD` | **pending author** |
| Config card screenshot | `TBD` | **pending author** |

## Confirmed (from experiment)

| | Laptop | Server |
|---|--------|--------|
| CPU | modern notebook | 2× Intel Xeon E5440 (2008) |
| RAM | 16 GB | 64 GB |
| GPU | RTX 4070 | none |
| Stack | Windows + LM Studio | llama.cpp (CPU) |
| Model | ~19–20 GB GGUF class | `deepseek-r1-distill-qwen-32b-q4_k_m.gguf` |
| Outcome | system freeze | loads, ~0.01 tok/s |

**Prompt:** write factorial in Forth (author used Russian prompt in session).

**Wall clock:**

| Time | Event |
|------|-------|
| 23:56 | llama.cpp launch |
| ~01:16 (+1:20 video) | fast forward starts (0.01 tok/s) |
| 05:48 | first Forth snippet copied from unfinished output → gforth FAIL |
| 06:51 | second snippet → gforth FAIL |

**Real inference duration:** ~7 hours for one prompt (estimated from wall clock).

## llama.cpp template (fill in)

```bash
# Example — replace with actual command from screencast
./llama-cli \
  -m deepseek-r1-distill-qwen-32b-q4_k_m.gguf \
  -p "Write a factorial word in Gforth." \
  -ngl 0 \
  -t TBD \
  -c TBD \
  --temp TBD
```

## gforth errors template (fill in)

**Version 1** (harvested ~05:48):

```
(paste snippet)
(paste gforth stderr/stdout)
```

**Version 2** (harvested ~06:51):

```
(paste snippet)
(paste gforth stderr/stdout)
```

## Related models (swan song shortlist)

- Qwen2.5 32B Q4
- QwQ 32B Q4_K_M (recommended demo pick)
- DeepSeek-R1 Distill Qwen 32B Q4_K_M (this run)
