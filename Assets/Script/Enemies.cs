using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int healthEnemies;
    public int damageEnemies;
    public TextMesh textMesh;
    private void Start()
    {
        textMesh.text = textMesh.text + ": " + healthEnemies;
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() is {} player)
        {
            player.health -= damageEnemies;
        }
        if (other.GetComponent<Bullet>() is {} Bullet)
        {
            healthEnemies -= 1;
            textMesh.text = "Здоровье: " + healthEnemies;
        }
    }

    private void Update()
    {
        if (healthEnemies < 1)
        {
            Destroy(gameObject);
        }
    }
    
}
