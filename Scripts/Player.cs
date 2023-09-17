using Godot;
using System;
using System.Diagnostics;

public partial class Player : CharacterBody2D {
	[Export] float speed;
	[Export] string bulletPath;

	public override void _PhysicsProcess(double delta) {
		Move((float)delta);
		Shoot();
	}

	void Move(float delta) {
		Velocity = speed * GetMoveInput();
		Position += Velocity;
	}

	void Shoot() {
		if (Input.IsActionJustPressed("shoot")) {
			PackedScene bullet = GD.Load<PackedScene>(bulletPath);
			Node2D instance = (Node2D)bullet.Instantiate();
			GetParent().AddChild(instance);
			instance.Position = Position;
		}
	}

	Vector2 GetMoveInput() {
		Vector2 vec = Vector2.Zero;
		if (Input.IsActionPressed("move_up")) {
			vec.Y -= 1;
		}
		if (Input.IsActionPressed("move_down")) {
			vec.Y += 1;
		}
		if (Input.IsActionPressed("move_left")) {
			vec.X -= 1;
		}
		if (Input.IsActionPressed("move_right")) {
			vec.X += 1;
		}
		
		return vec.Normalized();
	}
}
