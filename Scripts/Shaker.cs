using Godot;
using System;

public partial class Shaker : Node2D {
	[Export] float shakeDecay;
	[Export] float shakeAmplitude;
	[Export] float rotationAmplitude;

	float shakeAmount = 0;

	void StartShake() {
		shakeAmount = 1;
	}

	public override void _Process(double delta) {
		Shake(shakeAmplitude, rotationAmplitude, shakeAmount);
		shakeAmount *= shakeDecay;
	}
	 
	void Shake(float shakeAmp, float rotAmp, float amount) {
		RandomNumberGenerator rng = new();
		float xPos = rng.RandfRange(-1, 1) * shakeAmp;
		float yPos = rng.RandfRange(-1, 1) * shakeAmp;

		float rot = rng.RandfRange(-1, 1) * Mathf.DegToRad(rotAmp);

		Position = new Vector2(xPos, yPos) * amount;
		Rotation = rot * amount;
	}
}