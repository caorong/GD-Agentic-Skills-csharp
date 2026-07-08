---
name: godot-csharp-mastery
description: "Godot .NET C# mastery skill for converting GDScript patterns into idiomatic C#. Covers partial classes, lifecycle overrides, exports, signals, typed node lookup, resources, events, collections, and migration traps."
---

# Godot C# Mastery

Use this skill whenever a Godot answer would otherwise include GDScript. Output C# unless the user explicitly asks for historical comparison.

## Core Rules

- Use `using Godot;` and `public partial class MyNode : NodeType`.
- Use `_Ready`, `_Process`, `_PhysicsProcess`, `_Input`, `_UnhandledInput`, `_EnterTree`, `_ExitTree`.
- Use `[Export]` for inspector values and `[Signal] public delegate void NameEventHandler(...)` for custom signals.
- Prefer typed APIs: `GetNode<T>()`, `GetTree().CreateTimer(...)`, `GetViewport()`, `GetWorld2D().DirectSpaceState`.
- C# value-type properties such as `Position`, `Velocity`, `Scale`, and `Modulate` often need copy-modify-reassign.
- Avoid GDScript-only syntax: `extends`, `func`, `var x :=`, `@export`, `@onready`, `$Node`, `%Node`, `.gd`, and `gdscript` code fences.

## Standard Node Shell

```csharp
using Godot;

public partial class ExampleController : CharacterBody2D
{
    [Export] public float Speed { get; set; } = 240.0f;

    [Signal]
    public delegate void ActivatedEventHandler();

    private Sprite2D _sprite = null!;

    public override void _Ready()
    {
        _sprite = GetNode<Sprite2D>("Sprite2D");
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
        Velocity = direction * Speed;
        MoveAndSlide();
    }

    public void Activate()
    {
        EmitSignal(SignalName.Activated);
    }
}
```
