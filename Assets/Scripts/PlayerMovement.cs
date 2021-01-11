using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;

    [SerializeField] private AudioSource audioSource_;
    [SerializeField] private AudioClip sound_;

    [SerializeField] Transform groundCheck_; 
    [SerializeField] float groundCheckRadius_; 
    [SerializeField] LayerMask CollisionLayers_;

    [SerializeField] Rigidbody2D Rigidbody_;
    [SerializeField] Animator animator_;
    [SerializeField] SpriteRenderer spriteRenderer_;

    private bool isJumping_;
    private bool isGrounded_;

    private Vector3 velocity_ = Vector3.zero;
    private float horizontalMovement_;
    private float smoothTime_ = 0.05f;

    // Update is called once per frame
    void Update()
    {
        horizontalMovement_ = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded_)
        {
            isJumping_ = true;
        }

        Flip(Rigidbody_.velocity.x);

        float characterVelocity = Mathf.Abs(Rigidbody_.velocity.x);
        animator_.SetFloat("Speed", characterVelocity);
        animator_.SetBool("isJumping", isJumping_);
    }
    void FixedUpdate()
    {
        isGrounded_ = Physics2D.OverlapCircle(groundCheck_.position, groundCheckRadius_, CollisionLayers_);
        MovePlayer(horizontalMovement_);
    }

    void MovePlayer(float horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(horizontalMovement, Rigidbody_.velocity.y);
        Rigidbody_.velocity = Vector3.SmoothDamp(Rigidbody_.velocity, targetVelocity, ref velocity_, smoothTime_);

        if (isJumping_)
        {
            audioSource_.PlayOneShot(sound_);
            Rigidbody_.AddForce(new Vector2(0f, jumpForce));
            isJumping_ = false;
        }
    }

    void Flip(float velocity)
    {
        if (velocity > 0.1f)
        {
            spriteRenderer_.flipX = false;
        }
        else if (velocity < -0.1f)
        {
            spriteRenderer_.flipX = true;
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