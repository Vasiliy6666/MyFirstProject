using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    public TextMesh textMesh;
    public int scoreCount;

    private void Start()
    {
        textMesh.text = textMesh.text + ": " + scoreCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() is {} player)
        {
            player.score += scoreCount;
            Destroy(gameObject);
        }
        else if (other.GetComponent<Bullet>() is { } bullet)
        {
            bullet.creator.score += scoreCount;
            Destroy(gameObject);
        }
    }
}
