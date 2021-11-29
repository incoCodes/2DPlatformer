using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
   // These instance variables are only for player movement, I get access to these in order to get user input and add force in certain directions accordingly
    public float speed = 5f;
    private float horizontalInput;
    private Rigidbody2D _ridbod;
    private bool isJumping;
    public float jumpForce = 100f;

    // These instance varibles are for player animation, I get access to these in order to play and flip the animations if needed 
    private SpriteRenderer _amrRend;
    public Animator animator;
    public GameObject spawn;

    // These instance variables are for the rope swinging mechanic, I get access to these in order to check if the player is attached to the rope and the player's input and add force accordingly
    private HingeJoint2D hd;
    [SerializeField] private float pushForce = 10f;
    private bool attached = false;
    public Transform attachedTo;
    private GameObject disregrad;
    public GameObject Player;
      // Awake is called before the first frame update
   void Awake()
    {
        // Gets access to Player Components in the editor, so we can adjust them in the code
        _ridbod = GetComponent<Rigidbody2D>();
        _amrRend = GetComponent<SpriteRenderer>();
        hd = GetComponent<HingeJoint2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // This code gets access to the horizontal vectors and axis that are built into the editor and adds force based on the input the user pressed
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * speed * Time.deltaTime * horizontalInput);
        // This checks which input was pressed and flips the sprite along the x axis to change the animation from left to right or right to left
        if (horizontalInput > 0)
        {
            _amrRend.flipX = false;
        } else if (horizontalInput < 0)
        {
            _amrRend.flipX = true;
        }
        // This plays the animation based on a certain condition to show that the player is moving
        animator.SetFloat("Speed",Mathf.Abs(horizontalInput));
        
        // This checks if the player is grounded and adds force based on a certain input thats been pressed, This is to allow the player to jump while applying gravity so the player doesn't gravity infinitely
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            _ridbod.AddForce(Vector2.up * jumpForce);
            isJumping = true;
            animator.SetBool("isJumping", true);
        }
        // This checks to see if the player is out of the map and if the player is out the map then bring him back to the designated spawn point, this is so the player doesn't fall forever and stop the flow of the game

        if (transform.position.y <= -20f)
        {
            transform.position = spawn.transform.position;
        }
        // This allows the player to restart the level based on a certain input, this is here if so the player decided to retry the level they have that option
        if (Input.GetKeyDown(KeyCode.R))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           
            
        }

        // This is a method with all the rope inputs and physics
        CheckKeyboardInputs();


    }



   

    // This checks if the player is on the ground, this is here so that the player doesn't have infinite jumping and the gravity is applied
    private void OnCollisionEnter2D(Collision2D amr)
    {
        if(amr.gameObject.tag == "ground")
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }
    // This adds force left or right while the player is on the rope and it also checks if the player is attached to the rope, This allows the player to use the rope physics and mechanics
    void CheckKeyboardInputs()
    { 
        if (Input.GetKey(KeyCode.A))
        {
            if(attached)
            {
                _ridbod.AddRelativeForce(new Vector2(-1, 0) * pushForce);
            }
        }

        if(Input.GetKey(KeyCode.D))
        {
            if (attached)
            {
                _ridbod.AddRelativeForce(new Vector2(1, 0) * pushForce);
            }
        }
        // This gets a certain input from the player and checks to see if the player is currently in the jumping state then detaches the player from the ropes, this allows the player to swing from rope to rope
       if (Input.GetKeyDown(KeyCode.Space) && isJumping == true)
        {
            Detach();
        }    
    }
    // This attaches the player to the rope object, this is used to be able to start the rope swinging mechanic
    public void Attach (Rigidbody2D ropeBone)
    {
        ropeBone.gameObject.GetComponent<RopeSegment>().isPlayerAttached = true;
        hd.connectedBody = ropeBone;
        hd.enabled = true;
        attached = true;
        attachedTo = ropeBone.gameObject.transform.parent;

    }

    // This deattaches the player to the rope object, this is used so the player isn't stuck on the rope forever and he can actual leave from it
    private void Detach ()
    {
        hd.connectedBody.gameObject.GetComponent<RopeSegment>().isPlayerAttached = false;
        attached = false;
        hd.enabled = false;
        hd.connectedBody = null;
        StartCoroutine(AttachedNull());
    }
    // This is used to constantly tells the program that the player is attached to null, this is used to fix a bug that would let you attach and detach to the rope once
    IEnumerator AttachedNull()
    {

        yield return new WaitForSeconds(0.5f);
        attachedTo = null;

    }
   
    // This checks to see if the player is currently colliding with the rope and if its colliding with the rope then attach it to the rope, this is used to actually get the player stuck to the rope when they collide with it
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!attached)
        {
            if (collision.gameObject.tag == "Rope")
            {
                if (attachedTo != collision.gameObject.transform.parent)
                {
                    if (disregrad == null || collision.gameObject.transform.parent.gameObject != disregrad)
                    {
                        Attach(collision.gameObject.GetComponent<Rigidbody2D>());

                    }
                }
            }
        }
    }

}




