using Godot;
using System;

public class SpacePhysicsObject : KinematicBody2D
{
	[Export]
	public float Mass = 1;
	[Export]
	public Vector2 Velocity = Vector2.Zero;
	// Called when the node enters the scene tree for the first time.

	public float RotationalVelocity = 0;

	public override void _Ready()
	{

	}

	public void AddForce(float direction, float amount)
	{
		// Placeholder
		Vector2 directionVector = new Vector2(1, 0).Rotated(direction);

		Velocity += (directionVector * amount / Mass);
	}
	public void AddForce(Vector2 direction, float amount)
	{
		// Placeholder
		Velocity += (direction * amount / Mass);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
	{
		Vector2 acceleration = CalculateForce(delta) / Mass;
		
		KinematicCollision2D collision = MoveAndCollide(Velocity*delta + 0.5f*acceleration*delta*delta);
		Velocity += acceleration * delta;

		float angularAcceleration = CalculateTorque(delta) / CalculateMomentOfInertia();
		Rotation += RotationalVelocity*delta + 0.5f*angularAcceleration*delta*delta;
		RotationalVelocity += angularAcceleration*delta;

		AdditionalPhysics(delta);
		if (collision != null)
		{
			OnCollision((Node2D)collision.Collider);
		}
	}

	public virtual void OnCollision(Node2D body)
	{

	}

	public virtual Vector2 CalculateForce(float delta)
	{
		return new Vector2(0, 0);
	}

	public virtual float CalculateTorque(float delta)
	{
		return 0;
	}

	public virtual float CalculateMomentOfInertia()
	{
		return 100000000000000000;
	}

	public virtual void AdditionalPhysics(float delta)
	{
	}
}
