using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Animator playerAnim;
    public Transform frontCheck;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    public float movementSpeed;
    public float wallSlideSpeed;
    public float jumpForce;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;
    public float checkRadius;
    public static bool isHiding = false;

    private bool isSliding = false;
    private bool isJumping = false;
    private bool isRunning = false;
    private bool isWallJumping = false;
    private bool isTouchingFront = false;
    private bool isGrounded = true;
    private bool lookingRight = true;
    private float movement = 0f;
    private Rigidbody2D rigidBody;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (!isHiding) {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

            // Getting movement input
            movement = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.fixedDeltaTime;

            // Moving character
            rigidBody.velocity = new Vector2(movement, rigidBody.velocity.y);

            if (movement != 0) {
                isRunning = true;
            }
            else {
                isRunning = false;
            }

            // Change direction of character sprite
            if (movement > 0 && !lookingRight) {
                FlipPlayer();
            }
            else if (movement < 0 && lookingRight) {
                FlipPlayer();
            }

            // Getting jump input
            if (Input.GetButtonDown("Jump") && isGrounded) {
                playerAnim.SetTrigger("Jump");
                isJumping = true;
                rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }

            // Check for touching wall
            isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);

            // Slides on wall if touching and not on ground
            if (isTouchingFront && !isGrounded && movement != 0) {
                playerAnim.SetTrigger("Slide");
                isSliding = true;
            }
            else {
                isSliding = false;
            }

            // Speed down wall while sliding
            if (isSliding) {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, Mathf.Clamp(rigidBody.velocity.y, -wallSlideSpeed, float.MaxValue));
            }

            // Wall jump
            if (Input.GetButtonDown("Jump") && isSliding) {
                playerAnim.SetTrigger("WallJump");
                isWallJumping = true;
                Invoke("SetWallJumpFalse", wallJumpTime);
            }

            if (isWallJumping) {
                rigidBody.velocity = new Vector2(-movement, yWallForce);
            }

            if (rigidBody.velocity.y == 0) {
                isJumping = false;
            }

            // Update animator
            playerAnim.SetBool("IsJumping", isJumping);
            playerAnim.SetBool("IsRunning", isRunning);
        }
    }

    private void FlipPlayer() {
        // Flip character sprite depending on movement
        lookingRight = !lookingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void SetWallJumpFalse() {
        isWallJumping = false;
    }
}
