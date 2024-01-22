using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D Rigidbody;
    private Animator Anim;
    private SpriteRenderer Sprite;
    private BoxCollider2D Collider;

    [SerializeField] private LayerMask jumpGround;
    [SerializeField] private AudioSource jumpSE;

    private float goX = 0f;
    [SerializeField] private int moveSpeed = 7;
    [SerializeField] private int jumpForce = 7;

    private enum MovementState{ idle, running, jumping }
    public bool deathState = false;

    // Start is called before the first frame update
    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
        Collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, jumpForce);
            jumpSE.Play();
        }

        goX = Input.GetAxisRaw("Horizontal");
        Rigidbody.velocity = new Vector2(goX * moveSpeed, Rigidbody.velocity.y);

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;

        if (goX > 0f)
        {
            state = MovementState.running;
            Sprite.flipX = true;
        }
        else if (goX < 0f)
        {
            state = MovementState.running;
            Sprite.flipX = false;
        }
        else
        {
            state = MovementState.idle;
        }

        if (Rigidbody.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }

        Anim.SetInteger("movementState", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(Collider.bounds.center, Collider.bounds.size, 0f, Vector2.down, 0.1f, jumpGround);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            deathState = true;
        }
    }
}
