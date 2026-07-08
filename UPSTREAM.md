# Upstream Sync Guide

Original upstream repository:

- https://github.com/thedivergentai/GD-Agentic-Skills

This repository is a downstream Godot .NET / C# conversion fork. It is **not** currently connected through GitHub's built-in Fork metadata, so updates should be handled as a controlled downstream sync rather than a blind fast-forward.

## Why sync is not a simple merge

The upstream project is GDScript-first. This repository rewrites the skill contracts to C# and intentionally blocks new `.gd` implementation output. Because of that, upstream changes should be reviewed, converted, and committed through a sync branch.

## Tracked upstream revision

The last upstream commit reviewed by this fork is stored in:

```text
.upstream-revision
```

Current value:

```text
e9e20fffe2bd825e3c03c99a36096094b299974a
```

## Recommended manual sync flow

```bash
git clone https://github.com/caorong/GD-Agentic-Skills-csharp.git
cd GD-Agentic-Skills-csharp

git remote add upstream https://github.com/thedivergentai/GD-Agentic-Skills.git
git fetch upstream main

OLD_UPSTREAM=$(cat .upstream-revision)
NEW_UPSTREAM=$(git rev-parse upstream/main)

git log --oneline "$OLD_UPSTREAM..$NEW_UPSTREAM"
git diff --name-status "$OLD_UPSTREAM..$NEW_UPSTREAM"

git checkout -b sync/upstream-$(date +%Y%m%d)
```

Then review changed upstream files and port the relevant updates into the C# skill files. Do **not** blindly copy new `.gd` scripts into this repository as final output.

After conversion:

```bash
printf "%s\n" "$NEW_UPSTREAM" > .upstream-revision
git add .
git commit -m "chore: sync upstream changes and reapply C# conversion"
git push origin HEAD
```

Open a PR into `main`, review the C# conversion, and merge after validation.

## If you want a real GitHub fork relationship

GitHub does not normally let an existing independent repository become a built-in fork of another repository. To get the official Fork badge and network graph, the clean route is:

1. Rename this repository temporarily, for example `GD-Agentic-Skills-csharp-archive`.
2. Use GitHub's **Fork** button on `thedivergentai/GD-Agentic-Skills` into `caorong/GD-Agentic-Skills-csharp`.
3. Reapply this C# conversion branch on top of that real fork.
4. Continue syncing using GitHub's built-in **Sync fork** button or normal upstream merges.

For this C# edition, the safer day-to-day path is still PR-based downstream syncing because every upstream GDScript change needs C# conversion.
