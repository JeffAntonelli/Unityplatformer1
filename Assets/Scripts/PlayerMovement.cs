using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private bool isJumping_;
    private bool isGrounded_;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask CollisionLayers;


    public Rigidbody2D Rigidbody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public Vector3 velocity_ = Vector3.zero;
    public float horizontalMovement_;


    // Update is called once per frame
    void Update()
    {
        horizontalMovement_ = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded_)
        {
            isJumping_ = true;
        }

        Flip(Rigidbody.velocity.x);

        float characteVelocity = Mathf.Abs(Rigidbody.velocity.x);
        animator.SetFloat("Speed", characteVelocity);
        animator.SetBool("isJumping", isJumping_);
    }
    void FixedUpdate()
    {
        isGrounded_ = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, CollisionLayers);
        MovePlayer(horizontalMovement_);
    }

    void MovePlayer(float horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(horizontalMovement, Rigidbody.velocity.y);
        Rigidbody.velocity = Vector3.SmoothDamp(Rigidbody.velocity, targetVelocity, ref velocity_, 0.05f);

        if (isJumping_)
        {
            Rigidbody.AddForce(new Vector2(0f, jumpForce));
            isJumping_ = false;
        }
    }

    void Flip(float velocity)
    {
        if (velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
#endif
}