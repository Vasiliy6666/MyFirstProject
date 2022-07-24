using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public Rigidbody rigidbody3D;
    public float attractRadius;

    private void FixedUpdate()
    {
        foreach (var collider in Physics.OverlapSphere(transform.position, attractRadius))
        {
            if (collider.GetComponent<Attractor>() is { } attractor)
            {
                if(attractor == this) continue;
                Attract(attractor);
            }
        }
    }

    void Attract(Attractor objToAttract)
    {
        Rigidbody rdToAttract = objToAttract.rigidbody3D;

        Vector3 direction = rigidbody3D.position - rdToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitube = (rigidbody3D.mass * rdToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitube;
        
        rdToAttract.AddForce(force);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attractRadius);
    }
}
