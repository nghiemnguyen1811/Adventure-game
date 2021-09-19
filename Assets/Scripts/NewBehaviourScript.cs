using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 11f;
    [SerializeField]
    private float moveForce = 10f;
    private float movementX;
    [SerializeField]
    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;

    private string WALK_ANIMATION = "Walk";

    private bool isGrounded;

    private string GROUND_TAG = "Ground";
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoverKeyboard();
        AnimatePlayer();
    
    }
    private void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMoverKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }
    void AnimatePlayer()
    {
        //we are going on the right side
        if (movementX > 0 )
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        //we are going on the left side
        else if (movementX < 0 )
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            //Debug.Log("We land on the ground");
        }
    }
}//class












