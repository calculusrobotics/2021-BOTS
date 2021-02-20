using Godot;
using System;

public class SpacePhysicsObject : KinematicBody2D
{
    public bool Destroyed = false;
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
        
        collision = MoveAndCollide(Velocity*delta + 0.5*acceleration*delta*delta)
        Velocity += Acceleration * delta;

        float angularAcceleration = CalculateTorque(delta) / CalculateMomentOfInertia()
        Rotation += RotationalVelocity*delta + 0.5*angularAcceleration*delta*delta;
        RotationalVelocity += angularAcceleration*delta;


        if (collision != null)
        {
            OnCollision()
        }

        AdditionalPhysics(delta)
    }

    public void OnCollision()
    {

    }

    public Vector2 CalculateForce(delta)
    {
        return new Vector2(0, 0);
    }

    public float CalculateTorque(delta)
    {
        return 0;
    }

    public float CalculateMomentOfInertia()
    {
        return 100000000000000000;
    }

    public void AdditionalPhysics(delta)
    {

    }
}
