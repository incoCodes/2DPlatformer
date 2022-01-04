using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    // Assign an game object visible in the editior to the player object
    // This is so that we can call this object later and modify however we like with this script
    public GameObject player;

// This tells the program that if the enemy's collider collides with the player collider then kill or destory the player game object from the scene.
// This adds some difficulty in the game as the player can die from the enemy but can't kill the enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(player);
        }
    }
}
