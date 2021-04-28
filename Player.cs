using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Maska pro collider
    [SerializeField] private LayerMask platformsLayerMask;

    private Rigidbody2D rigidbody2d;
    private CapsuleCollider2D capsulecollider2d;
    
    //Obraz a animátor
    private SpriteRenderer spriteRender;
    public Animator animator;

    //Sila skoku
    public float jumpVelocity = 17f;

    //Rychlost
    public float moveSpeed = 8f;

    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        capsulecollider2d = transform.GetComponent<CapsuleCollider2D>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Po stisknuti klavesy Space
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        //Animace ve vzduchu
        if(IsGrounded())
        {
            animator.SetBool("inAir", false);    
        } else {
            animator.SetBool("inAir", true);
        }

        //Pohyb
        Movement();

        //Restartování levelu
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Level1");
        }

    }

    private bool IsGrounded()
    {
        RaycastHit2D raycasthit2d = Physics2D.CapsuleCast(capsulecollider2d.bounds.center, capsulecollider2d.bounds.size, CapsuleDirection2D.Vertical, 0f, Vector2.down, .1f, platformsLayerMask);
        //Debug.Log(raycasthit2d.collider);
        return raycasthit2d.collider != null;
    }

    private void Movement() 
    {

        //Po stisknuti klavesy A
        if (Input.GetKey(KeyCode.A)) {
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
            spriteRender.flipX = true;
            animator.SetBool("Movement", true);

        //Po stisknuti klavesy D
        }else{
            if (Input.GetKey(KeyCode.D)) {
            rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
            spriteRender.flipX = false;
            animator.SetBool("Movement", true);

        //Zadna klavesa
            }else{
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            animator.SetBool("Movement", false);
            }
        }
    }
}
