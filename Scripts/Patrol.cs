using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    // These instances variables are for the movement of the enemy, this is so we can give the enemy some life and have animal-like behaviour
    public float speed;
    public float distance;

    // This variable gets access to the sprite of the enemy, we use this to change the direction of the sprite and align with the direction its moving at
    private SpriteRenderer poss;

    // This variable checks if the enemy is moving right, we use this to check if he is moving right so if he isn't we can flip the sprite 
    private bool movingRight = true;

    // This variable checks the ground that is under the enemy, we use this to check if there is no ground so it can go the opposite direction
    public Transform groundDetection;

    // This varaible allows us to get access to the player, we can use this in order to adjust or change the player based on the conditions from the enemy
    [SerializeField]
    private GameObject player;
    
    // This allows us to get access to the sprite renderer and we flip the sprite, this is so that the enemy starts in the right direction when running the game
    private void Start()
    {
        poss = GetComponent<SpriteRenderer>();
        poss.flipX = true;
        
    }
    // This moves the enemy and checks if there is ground in front of them, if there is ground they will keep walking if not they will switch directions, keeping the enemy moving adds difficulty to the platforming
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        

        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundinfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector2(0, -180);
                poss.flipX = true;
                movingRight = false;
            } else
            {
                transform.eulerAngles = new Vector2(0, 0);
                movingRight = true;
                poss.flipX = true;
            }
        }
    }

    // This destroys or kills the player when he collides with the enemy in the game, this adds a certain level of difficultly in the game now the player must avoid enemies that kill him

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            Destroy(player.gameObject);
            

          
        }
    }
}
