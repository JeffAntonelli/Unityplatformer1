using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed; //ok.
    [SerializeField] float jumpForce; //ok.
    [SerializeField] private AudioSource audioSource_;
    [SerializeField] private AudioClip sound_;

    private bool isJumping_; //de base.
    private bool isGrounded_; //de base.

    public Transform groundCheck_; 
    public float groundCheckRadius_; 
    public LayerMask CollisionLayers_; 


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

        float characterVelocity = Mathf.Abs(Rigidbody.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        animator.SetBool("isJumping", isJumping_);
    }
    void FixedUpdate()
    {
        isGrounded_ = Physics2D.OverlapCircle(groundCheck_.position, groundCheckRadius_, CollisionLayers_);
        MovePlayer(horizontalMovement_);
    }

    void MovePlayer(float horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(horizontalMovement, Rigidbody.velocity.y);
        Rigidbody.velocity = Vector3.SmoothDamp(Rigidbody.velocity, targetVelocity, ref velocity_, 0.05f);

        if (isJumping_)
        {
            audioSource_.PlayOneShot(sound_);
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
        Gizmos.DrawWireSphere(groundCheck_.position, groundCheckRadius_);
    }
#endif
}