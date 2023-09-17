using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

public partial class JohnAnimation : AnimatedSprite2D {
	AnimatedSprite2D sprite;
	
	public override void _Ready() {
		sprite = GetNode<AnimatedSprite2D>(GetPath());
		sprite.Play();
	}
}