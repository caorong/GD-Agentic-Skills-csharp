# GDScript to Godot C# Migration Guide

| GDScript | Godot C# |
|---|---|
| `extends Node` | `public partial class MyNode : Node` |
| `func _ready()` | `public override void _Ready()` |
| `func _process(delta)` | `public override void _Process(double delta)` |
| `func _physics_process(delta)` | `public override void _PhysicsProcess(double delta)` |
| `@export var speed := 200.0` | `[Export] public float Speed { get; set; } = 200.0f;` |
| `signal damaged(amount)` | `[Signal] public delegate void DamagedEventHandler(int amount);` |
| `emit_signal("damaged", amount)` | `EmitSignal(SignalName.Damaged, amount);` |
| `$Sprite2D` | `GetNode<Sprite2D>("Sprite2D")` |
| `queue_free()` | `QueueFree()` |
| `move_and_slide()` | `MoveAndSlide()` |
| `Input.get_axis(...)` | `Input.GetAxis(...)` |
| `Input.get_vector(...)` | `Input.GetVector(...)` |

## Value-type property rule

Godot C# vector/color properties are commonly value types. Prefer copy-modify-reassign when changing nested fields.

```csharp
Vector2 velocity = Velocity;
velocity.Y += gravity * (float)delta;
Velocity = velocity;
```

## Repository rule

Implementation examples in this fork should be C# only. Historical GDScript can be mentioned only when showing a before/after migration.
