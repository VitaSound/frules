*Experiment screencast: [YouTube](https://www.youtube.com/watch?v=Tupm9NozcCI) · continuation of [the Forth + AI story](https://dev.to/ua3mqj/forth-zastavil-stradat-nieirosieti-2aih)*

{% embed https://www.youtube.com/watch?v=Tupm9NozcCI %}

Recently I wanted to run **19–20 GB** quantized models locally — on my work laptop. **RTX 4070**, Windows, **LM Studio**. Maybe I misconfigured something. I expected the model would **spread** across VRAM + RAM + NVMe, but all I got was a hard system freeze.

Then I remembered my old **2008 server** — **2× Intel Xeon E5440**, **64 GB RAM**, **no GPU**. I cloned the current **llama.cpp**, built it without any trouble, and ran it in pure CPU mode.

**Model:** `deepseek-r1-distill-qwen-32b-q4_k_m.gguf`  
**Prompt:** write factorial in Forth  
**Goal:** not speed, but an answer to the question: *can old iron with enough memory run a model that is quality-wise out of reach on my laptop?*

## Two machines, one model class

| | Laptop | Server |
|---|--------|--------|
| CPU | modern notebook | 2× Xeon E5440 |
| RAM | 16 GB | 64 GB |
| GPU | RTX 4070 8 GB | — |
| Stack | LM Studio (Windows) | llama.cpp (CPU) |
| Result | freeze | loads, runs |

The server takes quite a while to start with a model like this. On the overnight factorial run, end-to-end speed was about **~0.03 tok/s** (771 tokens in 6 h 50 min) — reasoning overhead and a long context, not a micro-benchmark.

After the screencast I ran **`llama-bench`** on the same box (CPU, **8 threads**, `-p 16 -n 16`) to see where the cliff is:

| Model | Params | File size | pp16 (t/s) | tg16 (t/s) |
|-------|--------|-----------|------------|------------|
| TinyLlama 1.1B Q6_K | 1.1B | 861 MiB | 13.20 | 6.57 |
| Gemma 4 E2B Q4_K_M | 4.7B | 3.2 GiB | 8.08 | 3.37 |
| Qwen2.5-Coder 7B Q4_K_M | 7.6B | 4.4 GiB | 2.51 | 1.25 |
| Gemma 4 E4B Q4_K_M | 7.5B | 5.0 GiB | 3.89 | 1.72 |
| Qwen2.5-Coder 14B Q4_K_M | 14.8B | 8.4 GiB | 1.22 | 0.65 |
| Qwen2.5-VL 32B Q4_K_M | 32.8B | 18.5 GiB | 0.52 | 0.29 |
| **DeepSeek-R1 Distill Qwen 32B Q4_K_M** | 32.8B | 18.5 GiB | 0.52 | 0.29 |

`pp16` = prompt processing (prefill), `tg16` = token generation — synthetic short runs. Same **~18.5 GiB** tier tops out around **0.29 tok/s** here; real chat with chain-of-thought was slower. Raw log: [`llama-bench.md`](llama-bench.md).

The experiment started around **23:56**. Then I turned on the screencast recorder and went to sleep. Woke up a couple of times to check the results. By morning I basically had two answer variants. In the recording I used **fast forward**, except for the moments where I test the code.

## Seven hours, two factorial attempts, none correct

At **05:48** the model still had not finished its reasoning chain, but there was already a Forth-looking snippet. I copied **version 1**, ran it in **gforth** — **did not work**: stack or syntax error.

But the stream was **still going**. So I waited.

At **06:51** there was a **second** factorial attempt. I ran that one too. **Failed again.**

New takeaway: a model not trained specifically on a programming language (Forth, for example) cannot really "program" in it — even when you use a large model.

## The Xeon swan song

It is practically hard to find practical value in experiments with 2008 hardware. What can such an old box do in the LLM era? Almost nothing — unless your goal is to heat the room.

For **launching** large Q4 models, **64 GB of system RAM** on my server beats **16 GB + 8 GB GPU**. But that is only the fact that it runs. You would not call **~0.3 tok/s** (bench) or **~0.03 tok/s** (real factorial run) comfortable to work with. I think I just need to tweak a few LM Studio settings and everything will work on the laptop.

For my goal of getting **working Forth code**, the large model did not help. You need the "factory": algorithm in a model-friendly IR, deterministic transpile, **gforth** as the judge. That is what I am building around Cursor — rules, skills, and MCP.

The E5440 platform is weak by modern standards — I would not pick it for PCIe GPU offload either. Here **RAM volume** was the only win condition.

## Takeaways

1. **VRAM is not the only barrier.** System RAM matters when the whole model lives in host memory on CPU. But in that case it is very slow.
2. **Slow inference is still inference.** 0.29 tok/s in `llama-bench` and ~0.03 tok/s on a real prompt are both a joke for chat; but for the question "will it run at all?" — we got an answer.
3. **Do not buy a GPU rack to find something out.** I already wrote myself a rule: *buy hardware after the experiment, not to finally start the experiment* — otherwise you too will have monsters like this in the closet: "old but not useless" (or are they useless after all?).
4. **Fail format.** Well, in the end I got two broken factorials in seven hours. Bad. But that lesson was cheaper than a month of Opus thinking loops (until you count how much went into building the Xeon).
