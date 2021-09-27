using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    float horizontalInput;
    private Rigidbody2D _ridbod;
    private bool isJumping;
    public float jumpForce = 100f;
    private Renderer _amrbod;
    private SpriteRenderer _amrRend;
    private BoxCollider2D _boxx;
    private Vector2 position = new Vector2(0f, 0f);
    public Vector2 blackPosition = new Vector2(0f, 0f);
    public Vector2 whitePosition = new Vector2(0f, 0f);
    public Animator animator;
         // Start is called before the first frame update
   void Start()
    {
        _ridbod = GetComponent<Rigidbody2D>();
        _amrbod = GetComponent<Renderer>();
        _boxx = GetComponent<BoxCollider2D>();
        _amrRend = GetComponent<SpriteRenderer>();

       

       // _amrbod.material.color = Color.grey;



    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * speed * Time.deltaTime * horizontalInput);
        if (horizontalInput > 0)
        {
            _amrRend.flipX = false;
        } else if (horizontalInput < 0)
        {
            _amrRend.flipX = true;
        }
        animator.SetFloat("Speed",Mathf.Abs(horizontalInput));

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            _ridbod.AddForce(Vector2.up * jumpForce);
            isJumping = true;
            animator.SetBool("isJumping", true);
           }

        if(Input.GetKeyDown(KeyCode.B))
        {
           
            _amrbod.material.color = Color.grey;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            
           _amrbod.material.color = Color.white;
        }



        if (_amrbod.material.color == Color.white)
        {
            Respawn(blackPosition);
        }

        if (_amrbod.material.color == Color.grey)
        {
            Respawn(whitePosition);
        }


      

    }

/*   public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }
*/

    void Respawn(Vector2 position)
    {
        if (transform.position.y <= -20f)
        {
            transform.position = position;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            transform.position = position;
        }
    }


    private void OnCollisionEnter2D(Collision2D amr)
    {
        if(amr.gameObject.tag == "ground")
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }


    
}
