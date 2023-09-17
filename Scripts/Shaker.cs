using Godot;
using System;

public partial class Shaker : Node2D {
	[Export] float shakeDecay;
	[Export] float shakeAmplitude;

	float shakeAmount = 0;

	void StartShake() {
		shakeAmount = 1;
	}

	public override void _Process(double delta) {
		ScreenShake(shakeAmplitude, shakeAmount);
		shakeAmount *= shakeDecay;
	}
	 
	void ScreenShake(float amp, float amount) {
		RandomNumberGenerator rng = new();
		float x = rng.RandfRange(-1, 1) * amp;
		float y = rng.RandfRange(-1, 1) * amp;

		Position = new Vector2(x, y) * amount;
	}
}