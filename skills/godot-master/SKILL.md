---
name: godot-master
description: "Master router for the C# edition of GD Agentic Skills. Chooses the right Godot .NET skill, enforces C# output, and blocks GDScript-only snippets."
---

# Godot Master — C# Edition

Route requests to the C# converted Godot skills in this repository.

## Always Do

- Prefer Godot .NET C# for every implementation.
- Use `.cs` file names and `csharp` code fences.
- Load `godot-csharp-mastery` before converting legacy GDScript examples.
- Preserve the original skill taxonomy so existing agent routing still finds the expected topic.

## Never Do

- Do not output new `.gd` files.
- Do not use `gdscript` fences as implementation output.
- Do not leave `extends`, `func`, `@export`, `$Node`, or `emit_signal` in final code.
- Do not claim a migration is compiled unless it has been tested in a Godot .NET project.
