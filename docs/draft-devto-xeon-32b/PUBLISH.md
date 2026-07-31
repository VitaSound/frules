# Publish on dev.to — Xeon 32B CPU inference

Standalone EN post (not Part 3 of frules series). Video companion, ~750 words.

## Files

| File | Purpose |
|------|---------|
| [`article.md`](article.md) | Edit here |
| [`devto-publish.md`](devto-publish.md) | Paste into dev.to editor |
| [`chapters.md`](chapters.md) | YouTube titles + chapter timestamps |
| [`FACTS.md`](FACTS.md) | OS, llama.cpp flags, gforth errors, video URL |

## Before publish

1. Fill [`FACTS.md`](FACTS.md): video URL, server OS, llama.cpp command, both gforth errors.
2. Update `article.md`: replace `TBD` video link; optional — paste exact gforth messages.
3. Sync: `cp docs/draft-devto-xeon-32b/article.md docs/draft-devto-xeon-32b/devto-publish.md`
4. Finish video edit; set final chapter T+ in [`chapters.md`](chapters.md) and YouTube description.
5. Upload video; embed URL in post.

## dev.to metadata

**Title:** `32B on a 2008 Xeon: When RAM Beats VRAM (and Forth Still Wins)`

**Tags:** `ai`, `llm`, `selfhosted`, `hardware`, `forth`

**Canonical URL:** optional — YouTube watch URL or leave empty

**Series:** none (standalone; cross-link [frules RU Part 2](https://dev.to/ua3mqj) / [fmix EN](https://dev.to/ua3mqj/fmix-a-package-manager-for-forth-37ld) in prose only)

## Steps

1. https://dev.to/new
2. Paste contents of [`devto-publish.md`](devto-publish.md).
3. Embed video: `{% embed https://www.youtube.com/watch/YOUR_ID %}`
4. Preview mobile — single hardware table should wrap OK.
5. Publish.

**Status:** draft ready in repo; live publish blocked until [`FACTS.md`](FACTS.md) has video URL (and optional gforth error text). No dev.to API token in project — author publishes manually via editor.

## YouTube description (template)

```
32B Q4 on 2× Xeon E5440, 64 GB RAM, no GPU — llama.cpp CPU only.
Laptop with RTX 4070 + 16 GB RAM froze on the same model class in LM Studio.

Model: deepseek-r1-distill-qwen-32b-q4_k_m.gguf
Prompt: factorial in Forth
~0.01 tok/s · ~7 h wall clock · two gforth failures

Chapters:
(paste from chapters.md after edit)

llama.cpp (fill from FACTS.md):
(paste command)

Related: frules — https://github.com/VitaSound/frules
dev.to write-up: (paste dev.to URL after publish)
```

## After publish

- [ ] Add dev.to URL to YouTube description
- [ ] Optional: link from frules README or CHANGELOG
- [ ] Optional: tweet/post with thumbnail `0.01 TOK/S`

## Do not include

- Long Track A / Cursor invoice recap
- tok/s benchmark tables (single anecdotal run)
- Part N numbering
