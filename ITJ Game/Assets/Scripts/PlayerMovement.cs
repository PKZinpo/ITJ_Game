using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Animator playerAnim;
    public Transform frontCheck;
    public LayerMask whatIsGround;

    public float movementSpeed = 1f;
    public float wallSlideSpeed = 1f;
    public float jumpForce = 1f;
    public float checkRadius;

    private bool isSliding = false;
    private bool isJumping = false;
    private bool isRunning = false;
    private bool isTouchingFront = false;
    private bool lookingRight = true;
    private float movement = 0f;
    private Rigidbody2D rigidBody;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {

        // Getting movement input
        movement = Input.GetAxisRaw("Horizontal");

        if (movement != 0) {
            isRunning = true;
        }
        else {
            isRunning = false;
        }

        // Getting jump input
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidBody.velocity.y) < 0.001f) {
            playerAnim.SetTrigger("Jump");
            isJumping = true;
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);

        if (isTouchingFront == true && Mathf.Abs(rigidBody.velocity.y) > 0.001f && movement != 0) {
            isSliding = true;
        }
        else {
            isSliding = false;
        }

        if (isSliding) {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, Mathf.Clamp(rigidBody.velocity.y, -wallSlideSpeed, float.MaxValue));
        }

        if (rigidBody.velocity.y == 0) {
            isJumping = false;
        }

        // Update animator
        playerAnim.SetBool("IsJumping", isJumping);
        playerAnim.SetBool("IsRunning", isRunning);
    }

    void FixedUpdate() {

        // Moving character
        transform.position += new Vector3(movement * movementSpeed * Time.fixedDeltaTime, 0, 0);

        if (movement > 0 && !lookingRight) {
            FlipPlayer();
        }
        else if (movement < 0 && lookingRight) {
            FlipPlayer();
        }

    }
    private void FlipPlayer() {
        // Flip character sprite depending on movement
        lookingRight = !lookingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
