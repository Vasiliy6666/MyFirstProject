using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaks : MonoBehaviour
{
    public int damageSpeaks;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Player>() is {} player)
        {
            player.health -= damageSpeaks;
        }
    }
}
