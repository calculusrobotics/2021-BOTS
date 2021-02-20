using Godot;
using System;

public class SpacePhysicsObject : KinematicBody2D
{
	[Export]
	public float Mass = 1;
	[Export]
	public Vector2 Velocity = Vector2.Zero;
	// Called when the node enters the scene tree for the first time.

	public Vector2 Velocity = 0;
	public float RotationalVelocity = 0;

	public float Mass = 1;

	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
	{
		float acceleration = CalculateForce(delta) / Mass;
		
		KinematicCollision2D collision = MoveAndCollide(Velocity*delta + 0.5*acceleration*delta*delta);
		Velocity += Acceleration * delta;

		float angularAcceleration = CalculateTorque(delta) / CalculateMomentOfInertia();
		Rotation += RotationalVelocity*delta + 0.5*angularAcceleration*delta*delta;
		RotationalVelocity += angularAcceleration*delta;

		AdditionalPhysics(delta);
		// Placeholder
		KinematicCollision2D collision = MoveAndCollide(Velocity);
		if (collision != null)
		{
			OnCollision((Node2D)collision.Collider);
		}
	}

	public virtual void OnCollision(Node2D body)
	{

	}

	public Vector2 CalculateForce(float delta)
	{
		return new Vector2(0, 0);
	}
		// Placeholder
		Vector2 directionVector = new Vector2(1, 0).Rotated(direction);

	public float CalculateTorque(float delta)
	{
		return 0;
		Velocity += (directionVector * amount / Mass);
	}

	public float CalculateMomentOfInertia()
	{
		return 100000000000000000;
	}

	public void AdditionalPhysics(float delta)
	{

		// Placeholder
		Velocity += (direction * amount / Mass);
	}
}
