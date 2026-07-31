sea@xeon:~/llama.cpp/build/bin$ ./llama-bench --model /xeonstore/arc/models/tinyllama-1.1b-chat-v1.0.Q6_K.gguf  -r 1 -p 16 -n 16
| model                          |       size |     params | backend    | threads |            test |                  t/s |
| ------------------------------ | ---------: | ---------: | ---------- | ------: | --------------: | -------------------: |
| llama 1B Q6_K                  | 860.86 MiB |     1.10 B | CPU        |       8 |            pp16 |         13.20 ± 0.00 |
| llama 1B Q6_K                  | 860.86 MiB |     1.10 B | CPU        |       8 |            tg16 |          6.57 ± 0.00 |

sea@xeon:~/llama.cpp/build/bin$ ./llama-bench --model /xeonstore/arc/models/lmstudio-community/gemma-4-E2B-it-GGUF/gemma-4-E2B-it-Q4_K_M.gguf  -r 1 -p 16 -n 16
| model                          |       size |     params | backend    | threads |            test |                  t/s |
| ------------------------------ | ---------: | ---------: | ---------- | ------: | --------------: | -------------------: |
| gemma4 E2B Q4_K - Medium       |   3.18 GiB |     4.65 B | CPU        |       8 |            pp16 |          8.08 ± 0.00 |
| gemma4 E2B Q4_K - Medium       |   3.18 GiB |     4.65 B | CPU        |       8 |            tg16 |          3.37 ± 0.00 |

sea@xeon:~/llama.cpp/build/bin$ ./llama-bench --model /xeonstore/arc/models/lmstudio-community/gemma-4-E4B-it-GGUF/gemma-4-E4B-it-Q4_K_M.gguf  -r 1 -p 16 -n 16
| model                          |       size |     params | backend    | threads |            test |                  t/s |
| ------------------------------ | ---------: | ---------: | ---------- | ------: | --------------: | -------------------: |
| gemma4 E4B Q4_K - Medium       |   4.95 GiB |     7.52 B | CPU        |       8 |            pp16 |          3.89 ± 0.00 |
| gemma4 E4B Q4_K - Medium       |   4.95 GiB |     7.52 B | CPU        |       8 |            tg16 |          1.72 ± 0.00 |


sea@xeon:~/llama.cpp/build/bin$ ./llama-bench --model /xeonstore/arc/models/lmstudio-community/Qwen2.5-Coder-14B-Instruct-GGUF/Qwen2.5-Coder-14B-Instruct-Q4_K_M.gguf  -r 1 -p 16 -n 16
| model                          |       size |     params | backend    | threads |            test |                  t/s |
| ------------------------------ | ---------: | ---------: | ---------- | ------: | --------------: | -------------------: |
| qwen2 14B Q4_K - Medium        |   8.37 GiB |    14.77 B | CPU        |       8 |            pp16 |          1.22 ± 0.00 |
| qwen2 14B Q4_K - Medium        |   8.37 GiB |    14.77 B | CPU        |       8 |            tg16 |          0.65 ± 0.00 |

sea@xeon:~/llama.cpp/build/bin$ ./llama-bench --model /xeonstore/arc/models/Qwen/Qwen2.5-Coder-7B-Instruct-GGUF/qwen2.5-coder-7b-instruct-q4_k_m.gguf  -r 1 -p 16 -n 16
| model                          |       size |     params | backend    | threads |            test |                  t/s |
| ------------------------------ | ---------: | ---------: | ---------- | ------: | --------------: | -------------------: |
| qwen2 7B Q4_K - Medium         |   4.36 GiB |     7.62 B | CPU        |       8 |            pp16 |          2.51 ± 0.00 |
| qwen2 7B Q4_K - Medium         |   4.36 GiB |     7.62 B | CPU        |       8 |            tg16 |          1.25 ± 0.00 |

sea@xeon:~/llama.cpp/build/bin$ ./llama-bench --model /xeonstore/arc/models/openfree/Qwen2.5-VL-32B-Instruct-Q4_K_M-GGUF/qwen2.5-vl-32b-instruct-q4_k_m.gguf  -r 1 -p 16 -n 16
| model                          |       size |     params | backend    | threads |            test |                  t/s |
| ------------------------------ | ---------: | ---------: | ---------- | ------: | --------------: | -------------------: |
| qwen2vl ?B Q4_K - Medium       |  18.48 GiB |    32.76 B | CPU        |       8 |            pp16 |          0.52 ± 0.00 |
| qwen2vl ?B Q4_K - Medium       |  18.48 GiB |    32.76 B | CPU        |       8 |            tg16 |          0.29 ± 0.00 |

sea@xeon:~/llama.cpp/build/bin$ ./llama-bench --model /xeonstore/arc/models/Donnyed/DeepSeek-R1-Distill-Qwen-32B-Q4_K_M-GGUF/deepseek-r1-distill-qwen-32b-q4_k_m.gguf  -r 1 -p 16 -n 16
| model                          |       size |     params | backend    | threads |            test |                  t/s |
| ------------------------------ | ---------: | ---------: | ---------- | ------: | --------------: | -------------------: |
| qwen2 32B Q4_K - Medium        |  18.48 GiB |    32.76 B | CPU        |       8 |            pp16 |          0.52 ± 0.00 |
| qwen2 32B Q4_K - Medium        |  18.48 GiB |    32.76 B | CPU        |       8 |            tg16 |          0.29 ± 0.00 |

