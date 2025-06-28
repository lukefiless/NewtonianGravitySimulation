using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
public class CelestialBody : GravityObject
{
    public float radius;
    public float mass;
    public Vector3 initialVelo;
    public string bodyName = "Unnamed";
    // Transform meshHolder;
    // public float surfaceGravity;

    public Vector3 velocity { get; private set; }
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
        velocity = initialVelo;
        Debug.Log($"[{name}] mass at Awake: {mass}");
    }

    public void UpdateVelo(CelestialBody[] allBodies, float timeStep)
    {
        foreach (var otherBody in allBodies)
        {
            if (otherBody != this)
            {
                float sqrDist = (otherBody.rb.position - rb.position).sqrMagnitude;
                Vector3 forceDir = (otherBody.rb.position - rb.position).normalized;

                Vector3 acceleration = forceDir * Universe.gravitationalConstant * otherBody.mass / sqrDist;
                velocity += acceleration * timeStep;
            }
        }
    }

    public void UpdateVelo(Vector3 acceleration, float timeStep)
    {
        velocity += acceleration * timeStep;
        Debug.Log($"[{name}] velocity updated");
    }

    public void UpdatePosition(float timeStep)
    {
        rb.MovePosition(rb.position + velocity * timeStep);
        Debug.Log($"[{name}] position updated");
    }

    void OnValidate()
    {
        // mass = surfaceGravity * radius * radius / Universe.gravitationalConstant;
        // meshHolder = transform.GetChild(0);
        // meshHolder.localScale = Vector3.one * radius;
        gameObject.name = bodyName;
    }

    public Rigidbody Rigidbody
    {
        get
        {
            return rb;
        }
    }

    public Vector3 Position
    {
        get
        {
            return rb.position;
        }
    }
}
