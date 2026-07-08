---
name: godot-characterbody-2d
description: "C# CharacterBody2D patterns: platformers, coyote time, jump buffering, variable jump height, wall jumps, dash states, top-down movement, slope handling, and collision response."
---

# CharacterBody2D — C# Edition

Use this skill for player, NPC, and enemy controllers built with `CharacterBody2D` in Godot .NET.

## Never Do

- Never multiply `Velocity` by `delta` before `MoveAndSlide()`.
- Never bypass collisions with direct `GlobalPosition` movement for normal controllers.
- Never leave old `velocity`, `is_on_floor()`, or `move_and_slide()` names in C# output.

## Basic Platformer Controller

```csharp
using Godot;

public partial class PlatformerController : CharacterBody2D
{
    [Export] public float Speed { get; set; } = 300.0f;
    [Export] public float JumpVelocity { get; set; } = -400.0f;

    private float _gravity;

    public override void _Ready()
    {
        _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!IsOnFloor())
            Velocity = new Vector2(Velocity.X, Velocity.Y + _gravity * (float)delta);

        if (Input.IsActionJustPressed("jump") && IsOnFloor())
            Velocity = new Vector2(Velocity.X, JumpVelocity);

        float direction = Input.GetAxis("move_left", "move_right");
        float targetX = direction != 0.0f ? direction * Speed : Mathf.MoveToward(Velocity.X, 0.0f, Speed);
        Velocity = new Vector2(targetX, Velocity.Y);

        MoveAndSlide();
    }
}
```
