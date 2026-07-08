using Godot;

namespace GdAgenticSkillsCSharp;

/// <summary>
/// Generic shell used by converted skills when a concrete Godot C# node example is needed.
/// Replace the base class and exported properties with the domain-specific node type.
/// </summary>
public partial class CSharpSkillTemplate : Node
{
    [Export]
    public bool Enabled { get; set; } = true;

    [Signal]
    public delegate void CompletedEventHandler();

    public override void _Ready()
    {
        if (!Enabled)
            return;

        GD.Print($"{nameof(CSharpSkillTemplate)} ready.");
    }

    protected void Complete()
    {
        EmitSignal(SignalName.Completed);
    }
}
