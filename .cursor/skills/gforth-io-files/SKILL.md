---
name: gforth-io-files
description: Implements Gforth file I/O with open-file, read/write buffers, and path handling per forth-io rules. Use for file-backed words, CLI args, search paths, or reading input streams in Gforth projects.
---

# Gforth file I/O workflow

## Rule file

`rules/forth-io.mdc` — open-file, close-file, read-file, paths, CLI args.

## Workflow

```text
1. Document file handle stack effects (wfileid, buffer, u)
2. Check error returns from open-file / read-file
3. Close files on all paths (including early exit)
4. Test with small fixture files
```

## Related skills

- `add-gforth-word` — project integration
- `lookup-gforth-manual` — exact open-file stack effects
- `gforth-verify-loop`
