# Authorship and disclaimers

> **Russian:** [DOC-AUTHORSHIP.md](DOC-AUTHORSHIP.md)

This note applies mainly to **`docs/FORTH-*.md`**, related **`data/forth-*.json`**, and **`rules/forth-system-context.mdc`** — material that grew as a **joint thought experiment** between a human and an AI, not as traditional documentation proofread cover to cover by the author.

---

## How it was produced

- The **human** sets direction, questions, criticism, idea selection, and what to commit or skip.
- The **AI** drafts, structures, links, expands, translates, and proposes diagrams and tables.
- **Iteration** is possible, but a **full human re-read audit** is **not guaranteed** — by volume or timeline.

In [`SOURCES.md`](SOURCES.md) these files are tagged **`AI-assisted (human-directed)`**, not “hand-authored”.

---

## Human author disclaimer

As the developer of this repository, I feel **strong discomfort (“cringe”)** about some wording, generalizations, and “architecture” in this documentation because:

- much of the text was **generated and assembled by AI**;
- I **cannot**, as a human, **fully grasp and re-read** the entire corpus;
- over time — **perhaps iteratively** — some of it may be revised, but **there is no promise of full proofreading**.

**I disclaim responsibility** for:

- absurd or overstated claims;
- technical misconceptions and stale generalizations;
- a confident tone where questions and doubt were needed;
- any conclusion a reader or model treats as “Forth community canon”.

This is **not** “everything is wrong”; it is **“not exhaustively verified by a human”**.

---

## For readers and agents

| Do | Don't |
|----|-------|
| Use as a **concept map**, hypotheses, code vocabulary (FMAP, layers) | Quote as **authoritative standard** or a substitute for primary sources |
| Cross-check **DPANS**, system manuals, target Forth sources | Blindly follow JSON profiles without target validation |
| Tag datasets with **provenance** and doc version | Mix these texts with ANS challenges without “AI-assisted doc” context |
| Send **issues, fixes, primary-source links** | Assume the maintainer has read everything |

For **writing code** and **challenges**, **`rules/forth-*.mdc`**, tests, and **`sources/`** remain primary.

---

## The experiment

We are **interested to see** where this joint experiment leads: a useful map for porting and model training, or a set of elegant but harmful abstractions. Pushback and corrections are welcome.

---

## Where this is linked

- Hub: [`FORTH-SYSTEM-ARCHITECTURE-eng.md`](FORTH-SYSTEM-ARCHITECTURE-eng.md)
- Provenance: [`SOURCES.md`](SOURCES.md)
- Agents: [`AGENTS.md`](../AGENTS.md), [`forth-system-context.mdc`](../rules/forth-system-context.mdc)

Other `docs/FORTH-*.md` inherit this note via the hub and `SOURCES.md`.
