using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaks : MonoBehaviour
{
    public int damageSpeaks;
       
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.GetComponent<Player>() is {} player)
        {
            player.health -= damageSpeaks;
        }
    }

}
