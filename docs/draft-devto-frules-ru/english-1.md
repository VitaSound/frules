... and My Cursor Bill

*Read the original in Russian: [Forth Made Neural Networks Suffer (and My Cursor Bill)](https://dev.to/ua3mqj/forth-zastavil-stradat-nieirosieti-2aih)*

# Fail of the Week

Inspired by the fact that with AI I managed to write a [package manager for Forth](https://dev.to/ua3mqj/fmix-pakietnyi-mieniedzhier-dlia-forth-o3p) literally in one evening, plus several modern utilities, I started thinking. It works out well, of course. But it's somehow expensive. What if I try to train a neural network and run it locally? I'd save money and gain experience!

---

For most modern programming languages, neural networks are quite ready. They were trained on metric tons of examples. But Forth somehow got skipped. I searched coder models for a list of languages they were trained on and couldn't find a model that lists Forth as supported. If we're talking about using models in Cursor, the most accessible agent—Auto—can't handle Forth programming at all. Here I "lost it" again and said—"let's go all in" (Opus 4.7)—solve it! In that mode the models actually started getting somewhere. Sometimes not on the first try. Sometimes really not on the first try, but still successfully.

Overall, Forth turned out to be a **tough nut** for neural networks: top models output something, but slowly, painfully, rewriting dozens of times, rearranging words, running tests, and accumulating context. Forth made **everything grind**—the hardware, and my wallet too. Not a triumph-of-Forth story—a slow lesson in how neural networks and the tooling around them actually work, while chasing an atypical AI problem and, as always, stepped on every rake. The goal shifted: build **AI that can beat Forth** without going broke.

---

## What is frules


![Image description](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/3y2awpjos9l5z7jjdip7.png)



Simple answer—you explain to AI how to write Forth and... Profit? Not so fast!

**[frules](https://github.com/VitaSound/frules)** is not "yet another ChatGPT prompt"

I had a hypothesis that AI simply doesn't know what Forth is and you just need to give it all the information. I thought that, of course, not out of nowhere, but after long chat dialogues with AI. After which we concluded that we need to assemble a knowledge dataset, and then the model would be able to program!

From what I knew, I asked AI to download the entire Gforth manual and examples of working with it. Write theses on Forth programming. I also added Brodie's book to the dataset, converting it to MD along the way (yay! now you can [read it online](https://github.com/VitaSound/frules/blob/main/sources/brodie-thinking-forth/chapter1.md)). After that, many generalized theses AI had already formed were rewritten almost completely. Plus, we tried to make a block of typical programming tasks, like on Codewars. The hardest part was that there were no solutions to the tasks, and I spent a lot of time and money having AI solve all 98 tasks so the solutions would pass the tests. In places it was genuinely painful. Because toward the end there were about 10 tasks at level 7 out of 10 on the difficulty scale. And each one took at least an hour.

From previous dialogues with AI it became clear that this stage would have to be solved on the smartest models. Set the right tasks, solve them correctly, and get working examples. A weak model won't solve the task, and won't even write a correct test. By solving tasks and getting the right answer, we essentially "extract" from the large model how it was trained to solve problems. On one task that no AI could solve in 2–3 attempts, I just checked the tests myself. And it turned out the test itself was wrong—incorrect expected answers were specified (neural network hallucinations), and one model fooled another, while the other vainly tried to solve the correct problem and verify it with the wrong test. As always, the third party suffered (me).

Then, after passing that checkpoint, I added library code from theForthNet and tasks from Rosetta with solutions (dang, I didn't have to solve those—everything's there!). But when the models analyzed it, things weren't that simple. First, the original dataset was logically split across knowledge areas so each had several solutions. And Rosetta tasks turned out to be mostly duplicates. So we took only about 10 of them, not 500+. Other tasks there were game-like and wouldn't (in AI's opinion) help learn programming. But the dataset could still be expanded. It also turned out the solutions exist, but they don't pass tests on gforth. From that point AI decided to start fixing those tests, but I stopped the process, realizing I couldn't endure another sprint of fixing broken tasks emotionally or financially—and we hadn't even gotten to training yet.

So the hardest part is behind me, I thought. The dataset is ready. But AI doesn't need all the material in raw form! It needs to take only specific distillations. At this stage AI, having processed everything, did what it calls "distillation" and formed a set of `.mdc` files on how to program. Grouping that information by topic along the way.

What came out in the end

- **rules** (`.mdc`) — distillation of Gforth manual, Brodie, Rosetta, theForthNet;
- **eval** — **151** challenges (**98** train / **53** hold-out blind);
- **gforth** — judge: every gold solution marked `TESTS OK`.

We got a library—a knowledge base you can install (via script) into your Forth project, and when working with AI it will use all these rule files.

Cursor picks up rules from `.cursor/rules/`

But in principle, I think you can read it yourself and understand something. It's hard to evaluate all of this. Validating everything alone takes a long time.

---

## Training your own model — Track A


![Image description](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/lefpz2iqj4cfdx1n1xgf.png)


Background. Before starting to "really" train a model—with data, on GPU—I had discovered RAG at work as a data source for the model. That is, we take a general-purpose model and connect an external vector database. We got a model of how our production is organized and could ask questions and get answers. Building a vector DB turned out to be an art form of its own. I watched from the sidelines as AI wrote scripts to "correctly" lay data into vectors. Then I'd ask questions and AI answered not how I wanted. And then the programming AI fixed the indexes. At that point I had a weak understanding of how it all works "under the hood." But I came to understand that for some of my work questions I don't need AI at all. I need to build tooling that fetches data, processes it, and outputs results. That knowledge would come in handy a bit later...

Assuming RAG wasn't quite what I wanted—I wanted to master the fine-tuning pipeline with my own data. That case where datasets are prepared somehow. Then you train the neural network and an extra layer of knowledge grows on it and boom—the model learned to program in Forth! Cool (I thought). My understanding at the time was: Model+RAG is when we have constantly changing knowledge. We easily swap the vector DB and don't need to retrain the model. But if we need to "bake" knowledge into the model—that's when we train it.

So I wouldn't wait forever for results, I asked AI to create this Track A for me: take the smallest 0.5B model, fine-tune it, see what it learned, understand the dataset assembly pipeline, training launch, and output. And only after that move on to larger models we'd train longer.

Well. My laptop has a 4070 with 8 GB and training is actually quite fast: literally a few minutes. The model is small. What did I get? A network that outputs repeatedly repeating nonsense instead of Forth code. Then we trained longer—added repetitions, I started staring at the numbers and felt I was starting to understand: epochs, error percentage. That percentage started dropping. But the final model still output a mix of Python code and Forth words.


![Image description](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/3t8kk9vufomw6hrcd9l0.png)


Then we discussed the result with AI and how to improve it. I wanted the network to output something more useful. Give it more data. But then I was reminded that I wasn't really supposed to get a normal result, because the goal was—to master the tooling pipeline! Damn. Still, I did manage to see the model learned something. At that moment Track A should have been closed—chalk it up as the first pancake—and move on (without trying to get something meaningful from the small model). But... My AI said there was a bug in my scripts: data was truncated and the model trained on the wrong stuff. OK—fix it! We trained on proper data. And miracle: the model... didn't learn to program in Forth, but there was progress! It started formatting results as syntactically valid Forth definitions `: forth-word commands ;` and I was even a little happy.

The Track A stage was decided closed—no more fine-tuning the 0.5B model. Why? Because the "sandbox" goal is done, but the dream "0.5B model learns Forth"—isn't. What remained was understanding why—it's not too few epochs, repetitions, or data. It's something fundamental I hadn't grasped yet.

## Time to take stock

*Pause after Track A—questions before buying more GPU.*

Many questions piled up, and without answers we couldn't move forward. Wild impulses started: buy my own powerful computer and GPU (which one?), maybe go to the institute, there's a cluster of 4×A100, or rent cloud. But for what?


![Image description](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/cdi14swh63fdryg5oapd.png)



While solving tasks, AI throws a lot of ML terminology. I collected them and started discussions. Plus, after experiments and measurements—you need to interpret results correctly, draw conclusions, and I didn't know how. So we had a long phase of talking to understand what we'd done, what conclusion to draw, and what to do next. We talked and talked, new questions appeared, new terms appeared. I asked follow-up questions on them. It's a good mechanism to learn what you don't know (we can't know what we don't know). We gradually spun up the dialogue.

Some questions I asked repeatedly, coming back many times. Apparently I just didn't want to believe some of my misconceptions.

The small model was planned from the start only for debugging the training pipeline and learning the tooling. But seeing the first results, I forgot all that and wanted to improve the network to get the right result—Forth code. And I stubbornly looked for ways to solve that.

### Stages of accepting the futility of building your own Forth-programming network


![Image description](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/2dfsm9em2njtkk6kxn1g.png)



AI: *The 0.5B model is too small and can't be trained. With that capacity it practically can't do anything. And it won't output Forth results and can't. Even top cloud models struggle.*

Before I accepted that thought, a whole chain of learnings and realizations happened. Surely not all of them are correct.

Realization +1: RAG is just text in the prompt. There is no direct connection between the neural network and the vector DB. There's no secret socket into the vector DB. All RAG data is inserted as text together with my original question in the prompt. All of that lands in context. The model understands that and starts answering accordingly.

Knowledge +1: Fine-tuning with LoRA—patterns baked into the weights via a thin adapter on a frozen base. You can merge and get a new model. But on my PC that's unrealistically slow. I may be wrong, but merge hits CPU and disk, and GPU doesn't help at all. So these are two different ways to add knowledge to the network. But with RAG—context is spent; with LoRA—it isn't.

Realization +1: LoRA doesn't replace RAG/rules in context. And context is only what exists—facts, theses. But overall, an answer with RAG can be better than from training.

Debating with AI about how and why to train a model—partial understanding appeared of why you shouldn't train too long on the same data, minimizing error. Train too long and the answer gets "memorized," but you want an answer through reasoning. That's why not every task in the dataset has an answer. So we teach the network via task–answer, then give a new task and expect an answer through reasoning. But we want an independent solution from the network. Then, having its reasoning—the answer—we can validate it because we have the correct answer for the task. Alas. It seems 0.5B isn't enough even to memorize answers.

Knowledge +1: Hold-out ("set aside")—tasks that weren't in training (neither in challenge-train.jsonl nor in train-merged for that slug). Used only to test the model blind, not how well it memorized the textbook.

What can you expect from a 0.5B network at all? And what to expect from a network in general? How does it work? We use networks and it's some kind of magic. Understanding how they work—that's higher magic. But at least understand what and how it answers.

Knowledge +1: a network is basically a predictor of the next correct token given the current context.

What? What do you mean?


![Image description](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/64m9p3ry1zpgyott9vr8.png)


Realization +1: understanding how AI "thinks," what it can output, which tasks it can solve and which it can't—one of the key moments for getting a developer tool.

And here I start guessing I'm going the wrong way entirely. I want direct Forth code generation from the neural network! But expecting reverse Polish notation (RPN (1 2 +)) generation directly from the network is a mistake. Neither because of small training data volume nor because of its nature—generating words sequentially—it can't undo its words and rearrange them (without an external tool).

Realization +1: services like Cursor just build a set of tools around a "thinking" model. Textual ones, because there's no other way to communicate. The model has one primitive: **question → answer**. What looks like an Agent with "reasoning" in the UI—**Cursor** under the hood: just several skills and MCP tools.

But the thought still won't leave me alone. Why do 0.5B models exist then?

Remember: no network runs Forth in its head, doesn't imagine a stack, doesn't keep one in memory. It can use context as a notepad, like a human. But you need a much larger network. Small models can do very simple things, like autocomplete.

Along the way it turned out model size is fixed too. LoRA won't "grow" 0.5B to other sizes by adding data. The network always stays the same size.

Then I tried to understand what we were actually training the network on. For example, I trained it on word definitions: factorial, fibonacci, etc. I saw loss change. It drops; seems like train longer and all will be well. I asked what that affects. But in the end I was told that loss down to 1 is normal training; below that is memorization. And there's no correct answer to when to stop training. Train to very low error and on prompt fib you get an exact, memorized answer. Like a student with 10 years of Russian but given some English words to memorize. They'll memorize them and only say those. But can't do anything else.

I also tried to understand how a neural network as a tree differs from a tree of Forth words and concepts. The model can understand and classify any part of a Forth expression. Each word is a separate concept. Maybe train on simple stack operations first, addition, etc. Turns out I didn't train the model on basics and immediately asked it to solve hard Forth tasks. Maybe that's why it doesn't solve them?

Knowledge +1: you can't make a model that writes Forth from a Python-trained model on 100 examples.

Knowledge +1: expecting exact formulations from a network is a mistake. The nature of the network is to err in small details and syntax—and it will definitely err in Forth syntax. Models are trained long and hard to generate JSON. Training a model from scratch—a home user doesn't have those resources (technical or dataset-wise).

But what did we achieve? At first I got a very strange answer from the small model. Then I fine-tuned. Saw the loss drops mentioned above, but nothing got better. Then it turned out there was prompt desync—an error in training data scripts. After fixing, answers looked somewhat like the truth. But only somewhat:

|Word|Model|Reference (tests/ans/)|
|---|---|---|
|gcd|begin dup 0= … while dup 0= … dup 1 swap gcd|begin dup while tuck mod repeat drop|
|factorial|0= if drop exit then 1* factorial|dup 1<= if drop 1 exit then dup 1- recurse *|
|divisible?|1 div 0= if 1 else 0|mod 0=|

The word definition was wrapped in the correct format `: word ( … ) … ;`—already not markdown/return format as before. But logic is wrong on all three. gforth fairly fails the tests.

The model doesn't copy strings from jsonl (gcd is in train)—0.5B can't hold the algorithm even with correct SFT.

But the smoke test wrote "OK" because it only checked for ":" at the start of the definition and ";" at the end. It doesn't compare to reference or require TESTS OK.


![Image description](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/5beugub9vv7fnq6s5xub.png)



Train had no basics in order of increasing difficulty (curriculum)—went straight to hard tasks (gcd/factorial). The table above is the outcome: even honest SFT didn't save it. Track A closed for good.

But the idea kept spinning in my head that logically a Forth tree and a neural network thinking tree are very similar and generating Forth code for a neural network is like writing down the classification path of what you realized. But I can't explain how to express that. And I don't know if that understanding can be applied to the result.

Again and again we discussed this and each time AI explained I can't do it that way. Better to get from AI a properly described algorithm in a language AI knows, or pseudocode, and use an external conversion utility to get Forth code! Because the utility does it fast, cheap, and accurately. Unlike the neural network, which does it by processing huge data arrays and still has a nonzero chance of erring on some letter. It's like hammering nails with a microscope.

After that I gave up. And admitted we have to do it that way. Plus I was already guessing that working directly with syntax and notation isn't programming yet. You still need to understand algorithms, data structures, and have experience solving tasks with algorithms and structures. Algorithmic tasks! And Coder models are trained for exactly that—you should use their output. And convert that output to Forth non-neurally.

How? I started asking—can models output AST? That's almost Forth. No direct answer that some model outputs AST was found, but per AI, during training models saw millions of trees from compiler textbooks. But to get AST, programmers supposedly ask for the answer as Lisp S-expressions.

Task: 1 + (2 * 3)

AST (Lisp format, which models generate well): (+ 1 (* 2 3))

Transpiler output to Forth: 1 2 3 * +

Forth and Lisp are mirrors. You can express one in terms of the other.

What else? Assembler? Not quite. Assembler for a stack VM? Yes!

```plaintext
Stack languages LLMs know 10 out of 10:
WebAssembly (WASM): In text form (.wat) WASM is a pure stack machine.
Java bytecode (JVM): JVM computation is strictly on the operand stack.
PostScript (PS): PDF printer language. Plot twist: PostScript is a Forth dialect! Same RPN, same words dup, pop (drop analog), exch (swap analog).
CIL (.NET bytecode) and Python bytecode (dis) — also stack-based.
```

Then I conclude the final Forth result can come another way—through an external conversion tool. As part of the toolset around the AI model—the so-called "factory."

I decided to stop at WASM

```plaintext
Look how strikingly similar WASM is to Forth:
WASM code (model writes it without errors):

get_local $a
get_local $b
i32.add
```

Then we dumbly replace and get Forth.


![Image description](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/kze7yz705vxea4ou68kq.png)


Well, let's sum up again:

My thesis: "Forth should be easy for a tree/neural network"

AI's answer: Forth is easy for a compiler, not for an autoregressive LLM:

LLM generates left to right; RPN requires "holding the operation in your head" while placing operands. Forth mixes data and metaprogramming (immediate, ['], create/does>)—the transformer doesn't "execute" that, only imitates text. So your chain "parse task → write as tokens" is right—but the middle (parse → RPN) must be an algorithm, not the network, and certainly not a 0.5B network.

After that I wanted to clearly separate "tool vs task" and which of my tasks should be solved by neural networks and which by "factory" ecosystem tools.

What not to expect from AI (architectural limits):

- Execute code, hold a stack "in its head," rollback on error—no internal VM; only text.
- Guaranteed correctness—never; only probability.

Then we talked a bit about training a model from scratch (not retuning from Python to Forth, but training on Forth from zero). That process is unviable for home development. You'd need to teach all levels of programming. But even with lots of money and specialists—the idea of generating Forth text is wrong. The network will still err; if not, that's hammering nails with a microscope.

But what can we do? We can build a "Factory" from the toolchain!

So we can get from a large model the essence of the algorithm and code in notation convenient for Forth translation. Convert with tools. Verify with tools. Deliver the answer. Thus we spare the large model the pain, suffering, and huge token spend of programming in Forth.

So the task changed a lot philosophically: AI shouldn't write Forth itself—it should use external tools to get Forth and verify the result. And for validating conversion, the Forth ecosystem tools built in a few days help: fmix + test, lint flint, fcov coverage.

If it works, we get Forth code cheaper. If Cursor+Opus runs on this tools functionality, results should be cheaper.

Thus we arrived at understanding and reinvented (the wheel)—what everyone calls skills/tools.

Realization: there are no monolithic AI neural nets that program. We don't use them. We use AI ecosystems that eventually produce program code. At home we run one mono model. Then we're surprised—why is it so dumb. But we're comparing one small model to a big set of large models and tools around them.


### AI terminology


![Image description](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/5oie7t8nt0towpiojr0y.png)



Terms AI actively used explaining how it works. There's a funny bit: we discuss AI with AI )) I'll give them as AI explained them to me. In the context of our dialogue. I think it's better to look up each word online for a more correct explanation. Here the list itself is what matters.

| Term | In plain words | What happens technically | For Forth / frules |
|--------|-------------|---------------------------|---------------------|
| **Parameter** | Network "memory cell" | One trainable number in a matrix | 0.5B = 500 million such numbers |
| **0.5B / 7B** | Model size / capacity | Parameter count; more → more patterns | 0.5B — too little for stack algorithms |
| **Pretrain** | "School of life" on the internet | Predict next token on huge corpus | Forth ≈ 0%; Python, C, "code in general" plenty |
| **Token** | Chunk of text (~word/part) | LLM input/output unit | `: gcd` may be 2–3 tokens |
| **Transformer** | LLM architecture | Attention: each token "looks at" previous ones | No stack, no VM — only text |
| **SFT** | Supervised fine-tuning | Textbook: prompt → reference answer | Your `train-merged.jsonl` |
| **Instruct / instruction-tuned** | "Assistant" model | SFT on "question → answer" dialogues | `Qwen2.5-Coder-0.5B-**Instruct**` |
| **LoRA** | Thin "overlay" | Few new weights; base frozen (QLoRA: 4-bit) | ~17 MB on top of 0.5B |
| **QLoRA** | LoRA + compressed base | Base in 4-bit, only adapter trains | Track A on RTX 4070 |
| **Loss** | Guessing error | Cross-entropy: how far off on next token | Low loss ≠ working Forth |
| **Epoch** | One pass over entire jsonl | How many times model saw each line | 3 ep on 139 lines — little for generalization |
| **Overfit / memorization** | Memorized train, doesn't transfer | Great on same prompts, bad on new | Old run: memorized **rules**, not gcd |
| **Generalization** | Transfer to new | Works on prompts/tasks outside train | 0.5B + Forth: practically none |
| **Memorization** | Copying train pairs | Answer ≈ string from jsonl | 0.5B didn't even do that for gcd |
| **Curriculum** | Simple to complex | First `1 2 +`, then `: square`, then gcd | Not in frules; needed for small models |
| **Hold-out** | Tasks not in train | Verification only | `eval_holdout` in `tests/challenges/` |
| **System prompt** | Role / rules in chat | First message `role: system` | SFT: short (~50 tok); Ollama: full rules |
| **Reasoning** | Step chain to answer | Model generates intermediate steps (CoT) | Forth stack = needs "scratchpad" or algorithm |
| **CoT (chain-of-thought)** | "Think aloud" in text | Answer: stack, analysis, then code | Helps **large** models; 0.5B breaks on long chain |
| **Rules (frules)** | Text in prompt, not weights | `.mdc` in SYSTEM; weights unchanged | Cursor / Ollama — stronger than LoRA 0.5B |
| **Merge LoRA** | Merge adapter into base | Full weights for Ollama/GGUF | Separate from Forth quality |
| **GGUF / Ollama** | Local inference format | Quantized model for chat | Rules in Modelfile ≠ train jsonl |


### Side products of this exciting week


![Image description](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/o1hvrps1zwwlc307k3pz.png)



While I was doing all this, some tools were created along the way. I wanted to estimate what we got: by time period, functionality, and code volume.

| Repo | Period | Versions | In one line | Code* |
|------|--------|--------|---------------|------|
| **fmix** | 2024 → 24.05 | 0.7.x | Package manager | ~1.2k LOC `.4th` |
| **fsemver** | 24.05, 1 day | 0.1.x | Semver library (for fmix/flint) | ~360 LOC |
| **fcov** | 24.05, 1 day | 0.1→**0.3** | Coverage tool: console/JSON/LCOV/HTML | ~2.8k LOC |
| **flint** | 24.05, 1 day | 0.1→**0.2.2** | Lint duplicate `: word` | ~825 LOC |
| **fenum** | 22.05 | 0.1.x | Library for `ulist` and `enum` (used in flint/fcov) | ~750 LOC |
| **fhdlgen** | 20–24.05 | 0.3.1 | DSL→Verilog converter (next time) | ~2k LOC |
| **frules** | 25–31.05 | 0.1.x | 151/98/53, Track A closed, docs hub | gold ~6.5k; rules ~2.1k md |

\*LOC excluding `forth-packages/` — just to gauge scale.

**May 24** — flint, fcov, fsemver written in one day with Opus 4.8. **frules** — six more days: challenge bank, gold, first checks (Track A), Forth docs hub.

Usually I hate wasting money on nothing. Not here: I don't regret the money or sleepless nights. Learned and realized too much in those days. Many skills helped on my day job too.

## In short: antipatterns

1. "Opus will write all the `: word ... ;` code" — overhard + overkill + overinvoice.
2. "LoRA will learn postfix" — no (Track A closed).
3. Expecting a "factory" from 0.5B — you get an intern, not an assembly line.
4. Generating Forth directly when you need IR → transpiler.


![Image description](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/qcway3gsbrejm1jthhe8.png)


*Five paid invoices in one week (May 23–29): $75.06 + $50.85 + $34.66 + $75.00 + $27.84 ≈ $263. The bill climbs with `rot` and thinking.*


![Image description](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/72olrggs0hetflxz4zz2.gif)


## What did we learn?


![Image description](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/p96sx7wc2ulnv5hzulm2.png)

*- What did we learn, Palmer?*
*- I don't know, sir.*
*- I don't know either. I guess we learned not to do it again.*
*- Yes, sir.*
*- I'm not sure what we actually did.*
*- Yes, sir. It's… hard to say.*
*- Good grief.*


## Sources

**VitaSound:** 
- [frules](https://github.com/VitaSound/frules)
- [feco](https://github.com/VitaSound/feco)
- [fmix](https://github.com/VitaSound/fmix)
- [fmcp](https://github.com/VitaSound/fmcp)
- [flint](https://github.com/VitaSound/flint)
- [fcov](https://github.com/VitaSound/fcov)
- [fsemver](https://github.com/VitaSound/fsemver) 

To be continued ...

