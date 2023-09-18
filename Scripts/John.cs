using Godot;
using System;
using System.Diagnostics;

public partial class John : RigidBody2D {
	AnimatedSprite2D sprite;

	[Export] float speed;

	[Signal] public delegate void UpdateHealthEventHandler(int health);

	float minXPos;
	float minYPos;
	float maxXPos;
	float maxYPos;

	Vector2 targetPos;
	
	int health = 100;

	public override void _Ready() {
		sprite = GetNode<AnimatedSprite2D>("Shaker/AnimatedSprite2D");

		Vector2 scrnSize = GetViewportRect().Size;
		minXPos = 0;
		minYPos = 0;
		maxXPos = scrnSize.X;
		maxYPos = scrnSize.Y / 2;

		Position = FindNewPosition();
		targetPos = FindNewPosition();
	}

	public override void _Process(double delta) {
		if (Position.DistanceTo(targetPos) < 10) {
			targetPos = FindNewPosition();
		}
		Position += (targetPos - Position).Normalized() * speed * (float)delta;
	}

	Vector2 FindNewPosition() {
		RandomNumberGenerator rng = new();
		return new Vector2(rng.RandfRange(minXPos, maxXPos), rng.RandfRange(minYPos, maxYPos));
	}

	void OnBodyEntered(Node body) {
		if (body.GetParent().Name != "Player") {
			return;
		}

		health -= 5;

		EmitSignal(SignalName.UpdateHealth, health);
	}
}
