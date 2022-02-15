using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [Header("Player properties")]
    [Tooltip("The speed at which the player moves")]
    [SerializeField] private float speed = 3f;
    [Tooltip("The speed modifier applied to the player when the player is moving")]
    public float speedModifier = 1f;
    [Tooltip("The force applied to the player when the player jumps")]
    public float jumpForce = 2.5f;
    private float horizontal = 0f;
    
    [Header("Player components")]
    [SerializeField] private Transform groundCheck;
    private Rigidbody2D body;
    private Animator animator;


    [SerializeField] private SpriteRenderer flashlight;
    public bool isFlashlightOn { get; private set; } = true;
    [SerializeField] private Sprite flashlightOn;
    [SerializeField] private Sprite flashlightOff;
    [SerializeField] private AudioClip[] JumpSound;
    [SerializeField] private AudioSource WalkSound;

    private Jetpack _jetpack;
    #endregion
    private void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        _jetpack = GetComponent<Jetpack>();
        

        // turn on flashlight sprite
        flashlight.enabled = true;
    }

    private void Update()
    {
        bool isGrounded = IsGrounded();

        //Check jumping & jetpack
        if (Input.GetKeyDown(KeyCode.Space) && !VisualNovel.IsPlaying)
        {
            if (isGrounded)
                Jump();
            if (_jetpack.IsUnlocked)
                _jetpack.JetpackSound.Play();
        }

        if (Input.GetKey(KeyCode.Space) && _jetpack.IsUnlocked && !VisualNovel.IsPlaying)
        {
            _jetpack.Use();
        }
        else
        {
            _jetpack.JetpackSound.Stop();
            _jetpack.Refuel();
        }

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

        if (isGrounded && Mathf.Abs(body.velocity.x) > 0.2)
        {
            WalkSound.Play();
        }
        else
        {
            WalkSound.Pause();
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

        Helper.PlayAudio(JumpSound[Random.Range(0, JumpSound.Length)]);
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