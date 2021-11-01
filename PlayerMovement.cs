using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    private float horizontalInput;
    private Rigidbody2D _ridbod;
    private bool isJumping;
    public float jumpForce = 100f;
    private Renderer _amrbod;
    private SpriteRenderer _amrRend;
    private BoxCollider2D _boxx;
    public Animator animator;
    public GameObject spawn;
    private HingeJoint2D hd;
    [SerializeField] private float pushForce = 10f;
    private bool attached = false;
    public Transform attachedTo;
    private GameObject disregrad;
         // Start is called before the first frame update
   void Awake()
    {
        _ridbod = GetComponent<Rigidbody2D>();
        _amrbod = GetComponent<Renderer>();
        _boxx = GetComponent<BoxCollider2D>();
        _amrRend = GetComponent<SpriteRenderer>();
        hd = GetComponent<HingeJoint2D>();

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

        if (transform.position.y <= -20f)
        {
            transform.position = spawn.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           
            
        }


        CheckKeyboardInputs();


    }

    /*   public void OnLanding()
        {
            animator.SetBool("isJumping", false);
        }
    */

   


    private void OnCollisionEnter2D(Collision2D amr)
    {
        if(amr.gameObject.tag == "ground")
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }

        
    }

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

       if (Input.GetKeyDown(KeyCode.Space) && isJumping == true)
        {
            Detach();
        }    
    }

    public void Attach (Rigidbody2D ropeBone)
    {
        ropeBone.gameObject.GetComponent<RopeSegment>().isPlayerAttached = true;
        hd.connectedBody = ropeBone;
        hd.enabled = true;
        attached = true;
        attachedTo = ropeBone.gameObject.transform.parent;

    }

    
    private void Detach ()
    {
        hd.connectedBody.gameObject.GetComponent<RopeSegment>().isPlayerAttached = false;
        attached = false;
        hd.enabled = false;
        hd.connectedBody = null;
        StartCoroutine(AttachedNull());


    }



    IEnumerator AttachedNull()
    {

        yield return new WaitForSeconds(0.5f);
        attachedTo = null;

    }


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




