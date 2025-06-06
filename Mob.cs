using Godot;
using System;

public partial class Mob : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		string[] mobTypes = animatedSprite2D.SpriteFrames.GetAnimationNames();
		// in the C# code, we pick a random number between 0 and 2 to select one of these names 
		// from the list (array indices start at 0). The expression GD.Randi() % n selects a random integer between 0 and n-1.
		animatedSprite2D.Play(mobTypes[GD.Randi() % mobTypes.Length]);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	// We also specified this function name in PascalCase in the editor's connection window.
	private void OnVisibleOnScreenNotifier2DScreenExited()
	{
		QueueFree();
	}
}
