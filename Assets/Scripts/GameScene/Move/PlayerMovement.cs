using UnityEngine;

public class RigidbodyPlayerMovement2D : MonoBehaviour, IMovement2D
{
    [SerializeField] private float speed = 5f;
    [SerializeField] public float jumpingPower = 10f;
    [SerializeField] private float index = 0.5f;
    [SerializeField] private float fallMultiplier = 2.5f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Animator playerAnimator;
    public Rigidbody2D rb;

    private bool isFacingRight = true;
    private const float GROUND_CHECK_RADIUS = 0.2f;

    private int movCheck = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontal, bool jumpDownBtn, bool jumpUpBtn)
    {
        MoveHorizontal(horizontal);
        MoveJump(jumpDownBtn, jumpUpBtn);
    }

    private void MoveHorizontal(float horizontal)
    {
        if (horizontal != 0)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(movCheck * speed, rb.velocity.y);
        }

        Flip(horizontal);
    }

    public void MoveLeft()
    {
        playerAnimator.SetBool("Run",true);
        movCheck = -1;
        Flip(movCheck);
    }

    public void MoveRight()
    {
        playerAnimator.SetBool("Run",true);
        movCheck = 1;
        Flip(movCheck);
    }

    public void MoveDown()
    {
        playerAnimator.SetBool("Run",false);
    }

    public void OnRelease()
    {
        movCheck = 0;
    }

    private void MoveJump(bool jumpDownBtn, bool jumpUpBtn)
    {
        if (jumpDownBtn && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (jumpUpBtn && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * index);
        }
    }

    public void JumpDown()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
    }

    public void JumpUp()
    {
        if (rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * index);
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, GROUND_CHECK_RADIUS, groundLayer);
    }

    private void Flip(float horizontal)
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        if (IsGrounded())
        {
            playerAnimator.SetBool("Jump",false);
        }        
        
        if (!IsGrounded())
        {
            playerAnimator.SetBool("Jump",true);
        }
        
    }
}


