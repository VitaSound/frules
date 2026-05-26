# Thinking Forth — Leo Brodie

Source for `frules` distillation. Original LaTeX from
[forthy42/thinking-forth](https://github.com/forthy42/thinking-forth)
(branch `ans_tf`), converted to per-chapter Markdown by `extract.sh`.

License: **CC BY-NC-SA 2.0**. See upstream `copyright.tex`.

## Layout

```
chapter1.md … chapter8.md     main text
appendixa.md … appendixe.md   appendices
epilog.md                     closing notes
figures/                      PNG figures (for human reading)
extract.sh                    fetch + convert pipeline
upstream/                     shallow clone (gitignored)
tmp/                          preprocessor scratch (gitignored)
```

## Rebuild

```bash
sudo apt install pandoc git    # one-time
bash extract.sh                # idempotent
```

The script:

1. Clones `forthy42/thinking-forth@ans_tf` into `upstream/` (shallow).
2. Copies all `*.png` from `upstream/` into `figures/`.
3. Preprocesses each chapter/appendix `.tex` (strips `\index`, `\Chapmark`,
   normalises `\Forth{}`, `\initial{X}`, `\person{}`, rewrites
   `\includegraphics{X}` to point at `figures/X.png`, renames the `Code`
   listing environment to `verbatim`).
4. Runs `pandoc --from=latex --to=gfm --wrap=none` per file.
5. Post-passes the markdown: tags Forth code fences with `forth` and warns
   about missing image targets.

## For AI consumers

Images are **kept for human reading only**. The distillation prompt in
`docs/DISTILL-PROMPT.md` instructs the model to drop `![](figures/…)`
references when extracting rules.
