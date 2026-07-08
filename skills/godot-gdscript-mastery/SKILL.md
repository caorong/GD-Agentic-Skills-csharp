---
name: godot-gdscript-mastery
description: "Compatibility alias for the former GDScript skill. In this C# edition, use godot-csharp-mastery and output Godot .NET C# only."
---

# GDScript Mastery — C# Compatibility Alias

This repository intentionally no longer teaches new GDScript implementations. The old role of this skill is preserved only as a migration checkpoint.

When a request references GDScript patterns, convert them to Godot .NET C#:

- `extends Node` -> `public partial class MyNode : Node`
- `func _ready()` -> `public override void _Ready()`
- `@export var value := 1` -> `[Export] public int Value { get; set; } = 1;`
- `signal changed` -> `[Signal] public delegate void ChangedEventHandler();`
- `emit_signal("changed")` -> `EmitSignal(SignalName.Changed);`
- `.gd` output -> `.cs` output

For active implementation guidance, load `skills/godot-csharp-mastery/SKILL.md`.
