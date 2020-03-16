using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask ground;
    Rigidbody2D rb;
    Vector2 force;
    Animator animator;
    AudioSource audioSource;

    public AudioClip clipJump;


    bool jumpPending = false;
    bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
        audioSource = GetComponent<AudioSource>();
        Debug.Log("Life remain = " + GameData.life);

    }

    // Update is called once per frame
    void Update()
    {
        
        force = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            force.x = -10;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            force.x = 10;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 feet = new Vector2(transform.position.x, transform.position.y - 0.75f);
            Vector2 dimensions = new Vector2(0.7f, 0.1f);
            bool grounded = Physics2D.OverlapBox(feet, dimensions, 0, ground);

            if(grounded)
            {
                jumpPending = true;
            }
        }

        if (force.x < 0)
        {
            animator.SetBool("isWalking", true);
            if(facingRight) Flip();
        }
        else if (force.x > 0)
        {
            animator.SetBool("isWalking", true);
            if(facingRight == false) Flip();
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        
    }

    private void FixedUpdate()
    {
        if(jumpPending)
        {
            force.y = 350;
            jumpPending = false;
            audioSource.clip = clipJump;
            audioSource.Play();
        }
        rb.AddForce(force);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -3,3), Mathf.Clamp(rb.velocity.y, -5,5));
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        facingRight = !facingRight;
    }


}
