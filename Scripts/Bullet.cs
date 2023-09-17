using Godot;
using System;

public partial class Bullet : RigidBody2D {
	[Export] float speed;

	public override void _PhysicsProcess(double delta) {
		Position += Vector2.Up * speed;
	}

	void OnBodyEntered(Node body) {
		if (body.GetOwner<Node>().Name == "Player") {
			return;
		}
		GetNode(GetPath()).QueueFree();
	}
}
