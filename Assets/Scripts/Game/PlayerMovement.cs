using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float speedModifier = 1f;
    public float jumpForce = 2.5f;
    private float horizontal = 0f;

    public Transform groundCheck;
    private Rigidbody2D body;
    private Animator animator;

    public SpriteRenderer flashlight;
    public bool isFlashlightOn = false;
    public Sprite flashlightOn;
    public Sprite flashlightOff;

    private void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bool isGrounded = IsGrounded();

        //Check jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();

        //Check controls
        horizontal = Input.GetAxis("Horizontal");

        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("Velocity", Mathf.Abs(horizontal));

        //Move character
        Vector3 moveBy = new Vector3(horizontal, 0, 0);
        transform.Translate(moveBy * Time.deltaTime * speed * speedModifier);
        Statistics.Increase(Statistics.Keys.MetersRan, Mathf.Abs(horizontal * Time.deltaTime * speed * speedModifier));

        //Flip character
        if (horizontal > 0.2f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontal < -0.2f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashlight();
        }

    }

    /// <summary>
    /// Check if character is colliding with ground
    /// </summary>
    public bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        foreach (Collider2D collider in colliders)
        {
            if (!collider.CompareTag("Player") && !collider.isTrigger)
                return true;
        }
        return false;
    }

    /// <summary>
    /// Check whether the character is falling or not by velocity
    /// </summary>
    /// <returns></returns>
    public bool IsFalling()
    {
        return body.velocity.y < -0.2;
    }

    /// <summary>
    /// Add force to player and start jumping animation
    /// </summary>
    public void Jump()
    {
        body.AddForce(new Vector2(0, jumpForce * 100));
        Statistics.Increase(Statistics.Keys.Jumps, 1);
        animator.SetTrigger("Jump");
    }

    public void ToggleFlashlight()
    {
        if (isFlashlightOn == false)
            flashlight.sprite = flashlightOn;

        if (isFlashlightOn == true)
            flashlight.sprite = flashlightOff;

        isFlashlightOn = !isFlashlightOn;
    }
}