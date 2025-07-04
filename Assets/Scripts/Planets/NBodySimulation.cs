using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NBodySimulation : MonoBehaviour
{
    CelestialBody[] bodies;
    static NBodySimulation instance;

    void Awake()
    {
        bodies = FindObjectsOfType<CelestialBody>();
        Time.fixedDeltaTime = Universe.physicsTimeStep;
        Debug.Log("Setting fixedDeltaTime to: " + Universe.physicsTimeStep);
    }

    void FixedUpdate()
    {
        for (int i = 0; i < bodies.Length; i++)
        {
            Vector3 acceleration = CalculateAcceleration(bodies[i].Position, bodies[i]);
            bodies[i].UpdateVelo(acceleration, Universe.physicsTimeStep);
        }

        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdatePosition(Universe.physicsTimeStep);
        }
    }

    public static Vector3 CalculateAcceleration(Vector3 point, CelestialBody ignoreBody = null)
    {
        Vector3 acceleration = Vector3.zero;
        foreach (var body in Instance.bodies)
        {
            if (body != ignoreBody)
            {
                float sqrDist = (body.Position - point).sqrMagnitude;
                Vector3 forceDir = (body.Position - point).normalized;
                acceleration += forceDir * Universe.gravitationalConstant * body.mass / sqrDist;
                Debug.Log($"[{body.name}] mass at CalcAcc: {body.mass}");
                Debug.Log($"[{body.name}] sqrDist at CalculateAcceleration: {sqrDist}");
                Debug.Log($"[{body.name}] forceDir at CalculateAcceleration: {forceDir}");
                Debug.Log($"[{body.name}] acceleration calculated at {acceleration}");
            }
        }
        
        return acceleration;
    }

    public static CelestialBody[] Bodies
    {
        get
        {
            return Instance.bodies;
        }
    }

    static NBodySimulation Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<NBodySimulation>();
            }
            return instance;
        }
    }
}