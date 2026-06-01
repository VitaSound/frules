# EN outline — translate by author after RU proofread

**Do not auto-translate.** Use this as section map + key phrases. Cross-link: [fmix EN](https://dev.to/ua3mqj/fmix-a-package-manager-for-forth-37ld), RU original (after publish).

---

## Title options

- **H0 (mirror RU):** Forth Made the Neural Gears Squeak (And My Cursor Bill). A Week of Fails and frules
- **Alt:** No Copilot for Forth: LoRA Fail, Opus Invoice, and frules

## Subtitle

Part 2 after fmix. Postfix, gforth, honest eval — not «one more LoRA».

---

## §1 Hook — «gears squeak»

- Python has Copilot; Forth doesn't — tested on Cursor Opus, LoRA 0.5B, gforth as judge
- Metaphor: **gears squeak** (softer than «models aren't ready»)
- Not «Forth beat AI» — story of postfix + stack + no Copilot → Agent at full throttle → **frules** (151 challenges, honest eval)
- F0 tease: «I thought I'd feed the model everything on Forth…» → Track A

## §2 frules punchline

- rules (.mdc) + **151 / 98 / 53** + gforth `TESTS OK`
- `./install.sh . gforth`
- Side toolchain: flint, fcov, Brodie→markdown

## §3 Fail → R&D → assets

- Diagram: Fail → R&D → understood / learned / conclusion
- Timeline table (rules, challenges, solve sprint, Track A closed, docs)
- May sprint table: fmix, fsemver, fcov, flint, fenum, fhdlgen, frules (LOC rounded)
- **Understood:** postfix not for raw generation. **Learned:** LoRA ≠ RAG ≠ rules. **Conclusion:** LLM→IR; tools→Forth; gforth→judge

## §4 Five stages + vibe coder

- Denial → Anger (invoice, WRONG NUMBER OF RESULTS) → Bargaining → Depression → Acceptance
- Vibe before/after: hammock vs 03:11 commit after gforth fail
- Invoice screenshot (~$102 on-demand, thinking-xhigh)

## §5 «Networks learn differently»

- Table: pretrain / SFT / LoRA / RAG / rules / tools
- LoRA = **weights**. RAG = **index**. Rules = **prompt**.
- Optional memes: RAG vs LoRA buttons, two pedals, highway exit

## §6 Postfix / IR / «using a cannon on sparrows»

- **Central thesis:** postfix alien to direct LLM generation; target Forth directly = mistake
- Solution: IR/pseudocode → transpiler → gforth
- Example: `(a+b)*c`, word ladder BFS, `WRONG NUMBER OF RESULTS`
- Three antipatterns: Opus writes `: word`, LoRA on postfix, mono 0.5B as factory
- **Bare NN doesn't program** — system: LLM + transpiler + gforth + human
- Diagram: ❌ LLM→.fs vs ✓ LLM→IR→tools→gforth

## §7 Cursor = service

- One primitive Q→A; Agent/thinking = Cursor sub-loops
- Invoice «thinking» lines = paid hidden turns
- Design loops with static tools inside

## §8 Factory not monolith

- Human → Architect LLM → Coder LLM → tools → gforth → FAIL/PASS
- 0.5B «intern» not «factory»
- Tier 0–3 link

## §9 Track A — main fail

- F0: feed everything on Forth → «pfft» (once, colloquial)
- F1 fake loss (4000 tok system, MAX_SEQ 1024)
- F2 honest fail (loss ~1.819, form OK, logic fail) — Track A **closed**
- F3 Opus + stack ($100+, rot loop)
- F6 gforth caught Agent (segfault 020, BFS 072)
- Sidebar: F4 RAG, F5 mono, F7 spend

## §10 Engineer role

- AI = draft; human = architect, verifier, PO
- 20 years = eval culture before model
- Opus = Tier 3 escalation only

## §11 Local factory

- Pipeline: KB → LLM→IR → transpiler → fmix/flint/fcov/gforth → hold-out
- Scripts at home (WSL), not cloud RAG magic
- `./install.sh . gforth` — star frules

## §12 Instead of epilogue — Palmer

- Fail week = asset in CHANGELOG
- «We learned not to do *that*» — Burn After Reading
- Palmer image final

## §13 Sources

- VitaSound repos, frules docs, Gforth manual, Brodie, Qwen, Unsloth, Cursor, Ollama

---

## Images (same as RU)

Must: cursor-invoice, ir-vs-forth, palmer  
Optional: stages, vibe, memes, factory, cursor-loop

## Tags

`#forth` `#ai` `#cursor` `#tooling` `#opensource` `#machinelearning`

## Numbers (keep exact)

151 challenges, 98 train, 53 hold-out — **not** 94/145
