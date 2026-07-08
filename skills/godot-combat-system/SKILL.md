---
name: godot-combat-system
description: "C# combat system patterns: hitbox/hurtbox components, DamageData resources, HealthComponent, combo windows, i-frames, cooldowns, and damage popups."
---

# Combat System — C# Edition

Use this skill for action/RPG/fighting combat implemented in Godot .NET C#.

## C# Component Contract

- Damage payloads should be typed `Resource` or immutable records where possible.
- Hitboxes and hurtboxes should communicate via C# events or Godot signals.
- Keep damage calculation separate from VFX/audio/UI response.
- Use `Area2D.BodyEntered += OnBodyEntered;` or `Area2D.AreaEntered += OnAreaEntered;` rather than stringly signal wiring.

```csharp
using Godot;

[GlobalClass]
public partial class DamageData : Resource
{
    [Export] public int Amount { get; set; } = 10;
    [Export] public float Knockback { get; set; } = 120.0f;
    [Export] public bool IsCritical { get; set; }
}

public partial class HealthComponent : Node
{
    [Export] public int MaxHealth { get; set; } = 100;

    [Signal]
    public delegate void DiedEventHandler();

    public int CurrentHealth { get; private set; }

    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
    }

    public void ApplyDamage(DamageData damage)
    {
        CurrentHealth = Mathf.Max(0, CurrentHealth - damage.Amount);
        if (CurrentHealth == 0)
            EmitSignal(SignalName.Died);
    }
}
```
