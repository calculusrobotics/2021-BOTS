using Godot;
using System;

public class Ship : SpacePhysicsObject, SpaceDamagable
{
    [Export]
    public float Fuel;
    [Export]
    public float MaxFuel;
    [Export]
    public float Speed;
    [Export]
    public int ShieldStrength;

    public bool CanLaserFire = true;

    public float ShipDensity = 4510;

    public float ExhaustRate = 10000;
    public float ExhaustSpeed = 18370617.0386; // m/s
    public float ExhaustAngle = 0;


    public float Height = 100; // 100 meters tall
    public float Width = 12; // true to sprite shape

    public float ALUMINUM_DENSITY = 2.7*1000;
    public float WATER_DENSITY = 997;

    public float FuelPercentage = 1 - 1/Math.E; // 90% of it is for fuel
    public float Thickness = 1;
    public float AluminumVolume = (Height*Thickness*2 + (Width - 2*Thickness)*2*Thickness)*Width + (Height-2*Thickness)*(Width-2*Thickness)*Thickness; 
    public float AluminumMass = AluminumVolume * ALUMINUM_DENSITY; // 2.7 g/cm^3
    public float RocketVolume = Height*Width*Width;
    public float FueledMass = AluminumMass / (1 - FuelPercentage);
    public float FuelSpace = 0.8*Height;
    public float InsideArea = Math.Pow(Width - 2*Thickness, 2);
    public float FuelDensity = FueledMass / (InsideArea * FuelSpace);


    public enum Weapon
    {
        Missile,
        Laser,
        Railgun
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        // AddForce(Direction, Speed);
    }
    public void FireWeapon(Node2D target, Weapon weapon)
    {
        if (weapon == Weapon.Missile)
        {
            // fire missile
        }
        else if (weapon == Weapon.Laser)
        {
            if (target is SpaceDamagable damagable)
            {
                damagable.Hit();
                CanLaserFire = false;
            }
        }
        else if (weapon == Weapon.Railgun)
        {
            // fire rail
        }
    }

    public void Hit()
    {
        if (ShieldStrength > 0)
        {
            ShieldStrength -= 1;
        }
        else
        {
            Destroyed = true;
            QueueFree();
        }
    }

    public override Vector2 CalculateForce(float delta)
    {
        return (new Vector2(ExhaustRate * dt * ExhaustSpeed, 0)).rotated(ExhaustAngle + Rotation);
    }

    public float CalculateTorque(float delta)
    {
        float comExterior_weighted = Height/2 * 4 * (Thickness)*(Width - Thickness) * ALUMINUM_DENSITY;
        float comTop_weighted      = (Height - Thickness/2) * (Thickness)*InsideArea * ALUMINUM_DENSITY;
        float comFuelSep_weighted  = (FuelSpace + Thickness/2) * (Thickness)*InsideArea * ALUMINUM_DENSITY;

        float fuelHeight = FueledMass / (FuelDensity * InsideArea);
        float comFuel_weighted = (fuelHeight / 2) * FueledMass;

        
    }

    public float CalculateMomentOfInertia()
    {

    }

    public override void AdditionalPhysics(float delta)
    {
        Mass -= ExhaustRate * delta;
    }
}
