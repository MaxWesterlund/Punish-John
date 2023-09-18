using Godot;
using System;

public partial class HealthBar : ColorRect {
	ColorRect colorRect;

	[Export] float maxSize;

	Vector2 preSize;
	Vector2 size;
	float lerp;

	public override void _Ready() {
		colorRect = GetNode<ColorRect>(GetPath());
		OnHealthChange(100);
	}

	public void OnHealthChange(float health) {
		Size = new Vector2(GetViewportRect().Size.X * maxSize * health / 100f, colorRect.Size.Y);
		Position = new Vector2(GetViewportRect().Size.X / 2 - Size.X / 2, Position.Y);
	}
}
