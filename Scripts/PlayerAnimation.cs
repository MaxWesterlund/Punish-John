using Godot;
using System;
using System.Diagnostics;

public partial class PlayerAnimation : AnimatedSprite2D {
	CharacterBody2D body;
	AnimatedSprite2D sprite;

	public override void _Ready() {
		body = (CharacterBody2D)GetParent();
		sprite = GetNode<AnimatedSprite2D>(GetPath());
		sprite.Play();
	}
	
	public override void _Process(double delta) {
		float rot = -0.2f * (Mathf.Acos(body.Velocity.Normalized().X) - Mathf.Pi / 2);
		if (body.Velocity.Normalized().Y > 0) {
			rot *= body.Velocity.Normalized().Y;
		}
		Rotation = (float)Mathf.Lerp(Rotation, rot, delta * 10);
	}
}
