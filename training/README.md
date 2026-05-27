# training/

Configs and optional scripts for LoRA SFT. **Main guide:** [`docs/MODEL-TRAINING.md`](../docs/MODEL-TRAINING.md).

| Path | Purpose |
|------|---------|
| `configs/sandbox.yaml` | Track A hyperparameters |
| `configs/prod-7b.yaml` | Track B hyperparameters |
| `requirements-train.txt` | Python deps (pin after first success) |
| `Modelfile.example` | Ollama template after GGUF export |

Weights go to `../output/` (gitignored).
