using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;

    private SpriteRenderer poss;

    private bool movingRight = true;

    public Transform groundDetection;
    
    
    private void Start()
    {
        poss = GetComponent<SpriteRenderer>();
        poss.flipX = true;
        
    }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            poss.color = Color.red;
            Destroy(this.gameObject);
            

          
        }
    }
}
