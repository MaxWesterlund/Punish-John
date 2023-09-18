using Godot;
using System;

public partial class HealthBar : ColorRect {
	ColorRect colorRect;

	[Export] float maxSize;

	Vector2 size;

	public override void _Ready() {
		colorRect = GetNode<ColorRect>(GetPath());
		OnHealthChange(100);
	}

	public override void _Process(double delta) {
		colorRect.Size = colorRect.Size.Lerp(size, 10 * (float)delta);
		Position = new Vector2(GetViewportRect().Size.X / 2 - colorRect.Size.X / 2, Position.Y);
	}

	public void OnHealthChange(float health) {
		size = new Vector2(GetViewportRect().Size.X * maxSize * health / 100f, colorRect.Size.Y);
	}
}
