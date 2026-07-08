# GD Agentic Skills — C# Edition

This repository is the Godot .NET / C# conversion baseline for `thedivergentai/GD-Agentic-Skills`.

The upstream skill taxonomy is preserved, but the implementation contract is changed from GDScript to C#:

- output `.cs` files and `csharp` code fences;
- use `using Godot;` and `public partial class ... : NodeType`;
- use `[Export]`, `[Signal]`, typed `GetNode<T>()`, C# events, and PascalCase Godot APIs;
- do not generate new `.gd` implementation files;
- keep legacy skill names so existing routing still works.

## Entry points

- `skills/godot-master/SKILL.md` — C# master router.
- `skills/godot-csharp-mastery/SKILL.md` — Godot .NET conversion rules.
- `skills/godot-gdscript-mastery/SKILL.md` — compatibility redirect.
- `MIGRATION_GUIDE.md` — GDScript to C# cheatsheet.
- `skills_index.json` — machine-readable converted skill index.

## Status

This is the first full-taxonomy C# conversion pass. Every top-level skill has a C#-first `SKILL.md` contract. Representative deep examples are included for C# mastery, CharacterBody2D, and combat components. Line-by-line ports of every upstream production script should still be compiled and validated inside a Godot .NET project before they are treated as production-ready.
