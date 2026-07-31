# Video chapters and on-screen titles

Use for YouTube **Chapters** (description) and editor overlays.  
**T+** = position in edited video. **Clock** = wall clock during capture.

Update **T+** column after montage (fast-forward segments). Clock times stay fixed.

---

## Main title (pick one)

**Recommended:**
> **32B on a 2008 Xeon: 0.01 tok/s, 7 Hours, Two Broken Forth Factorials**

| Angle | Title |
|-------|-------|
| Irony | My 64 GB Server Beat My RTX 4070 Laptop — Then Forth Said No |
| Swan song | Swan Song Inference: Running Q4 32B on Dual Xeon E5440 (No GPU) |
| Fail format | Fail of the Week: 32B Reasoning Model vs. One Line of Forth |
| Clickbait-light | I Ran DeepSeek-R1 32B on 17-Year-Old Server Hardware |

**Subtitle / cover line:** `2× Xeon E5440 · 64 GB RAM · llama.cpp · no GPU · ~0.01 tok/s`

**Thumbnail text options:** `0.01 TOK/S` · `7 HOURS. 2 FAILS.` · `32B ON XEON`

---

## Chapter list (YouTube description format)

Copy block below into video description. **Remeasure T+ after montage** — block below uses *estimated* times for a ~8–10 min final cut.

```
0:00 The Setup: 64 GB Swan Song
0:30 Launch: DeepSeek-R1 Distill Qwen 32B Q4_K_M
1:00 Config Card
1:20 0.01 tok/s — Fast Forward Starts
2:45 First Harvest: Copy-Paste Factorial #1
3:15 gforth: FAIL #1
3:30 Plot Twist: The Model Wasn't Done
4:15 Second Harvest: Factorial #2
4:45 gforth: FAIL Again
5:30 Verdict: RAM Wins Size, Forth Wins Architecture
```

*Estimates assume ~1:20 real-time opening + compressed fast-forward (~3:25) + ~2 min for both fails and outro. Replace with measured values.*

### Mapping clock → narrative (fixed)

| Clock | Event |
|-------|-------|
| 23:56 | Launch |
| ~01:16 | End of real-time segment; fast forward |
| 05:48 | First snippet harvested |
| 06:51 | Second snippet harvested |

---

## Full chapter table (editor reference)

| # | T+ (edit after montage) | Clock | On-screen title | Notes |
|---|-------------------------|-------|-----------------|-------|
| 0 | 0:00 | — | **The Setup: 64 GB Swan Song** | Goal, prompt, model, laptop vs server |
| 1 | 0:30 | 23:56 | **Launch: DeepSeek-R1 Distill Qwen 32B Q4_K_M** | llama.cpp load, ~20 GB RAM |
| 2 | 1:00 | ~01:00 | **Config Card** | E5440×2, 64 GB, no GPU, ctx, threads — see FACTS.md |
| 3 | 1:20 | ~01:16 | **0.01 tok/s — Fast Forward Starts** | «Real time ≈ 7 hours» |
| 4 | 2:45 *(est.)* | 05:48 | **First Harvest: Copy-Paste Factorial #1** | Unfinished reasoning trace |
| 5 | 3:15 *(est.)* | ~05:50 | **gforth: FAIL** | Show actual error from FACTS.md |
| 6 | 3:30 *(est.)* | — | **Plot Twist: The Model Wasn't Done** | Stream still running |
| 7 | 4:15 *(est.)* | 06:51 | **Second Harvest: Factorial #2** | Longer think, same result |
| 8 | 4:45 *(est.)* | — | **gforth: FAIL Again** | Punchline |
| 9 | 5:30 *(est.)* | — | **Verdict: RAM Wins Size, Forth Wins Architecture** | Swan song + frules link |

---

## Short overlays (between scenes)

- `Laptop: 16 GB + 4070 → LM Studio → freeze`
- `Server: 2008 Xeon → llama.cpp → it loads`
- `Not for speed. For the question.`
- `32B "reasoning" ≠ working postfix`
- `Tools + judge > bigger model alone` → frules

---

## Post-edit checklist

1. Measure T+ for chapters 4–9 after fast-forward cuts.
2. Paste final `0:00 Title` block into YouTube description (must start at 0:00, min 3 chapters).
3. Copy gforth errors into [`FACTS.md`](FACTS.md).
4. Update [`article.md`](article.md) video URL and error lines.
5. `cp article.md devto-publish.md`
