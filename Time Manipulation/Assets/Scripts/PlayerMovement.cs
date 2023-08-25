using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpForce = 15f;
    private float velocity;
    private bool jump, canDoubleJump, facingRight;

    private Rigidbody2D rb2d;

    void Start()
    {
        facingRight = true;

        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        velocity = Input.GetAxis("Horizontal") * speed;

        if (Input.GetKeyDown(KeyCode.Space)) jump = true;

        if ((velocity < 0 && facingRight) || (velocity > 0 && !facingRight)) Flip();
    }

    private void Jump()
    {
        if (IsGrounded()) 
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            canDoubleJump = true;   
        }
        else if (canDoubleJump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            canDoubleJump = !canDoubleJump;
        }

        jump = !jump;
    }

    private void FixedUpdate()
    {
        if (jump) Jump();

        rb2d.velocity = new Vector2(velocity, rb2d.velocity.y);
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, groundLayer);
        return hit;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "TestTrigger") // TODO: Make some more traps :D
        {
            col.gameObject.GetComponent<TriggerTrap>().MakeTrapFall();
        }
    }

    private void Flip()
    {
        transform.Rotate(new Vector3(0f, 180f, 0f));

        facingRight = !facingRight;
    }

    public IEnumerator ChangeMovementStats(float speedMultiplier, float jumpMultiplier, float duration)
    {
        speed *= speedMultiplier;
        jumpForce *= jumpMultiplier;

        yield return new WaitForSeconds(duration);

        speed /= speedMultiplier;
        jumpForce /= jumpMultiplier;
    }
}
