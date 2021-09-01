using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 2.5f;
    public Transform groundCheck;
    private Rigidbody2D body;
    private float horizontal = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Check if character is on ground
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        bool isGrounded = false;
        foreach (Collider2D collider in colliders)
        {
            if (!collider.CompareTag("Player"))
            {
                isGrounded = true; break;
            }
        }

        //Check jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            body.AddForce(new Vector2(0, jumpForce * 100));

        //Check controls
        horizontal = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        //Move character
        Vector3 moveBy = new Vector3(horizontal, 0, 0);
        transform.Translate(moveBy * Time.fixedDeltaTime * speed);

        //Flip character
        if (horizontal > 0.2f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontal < -0.2f)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    public bool IsFalling()
    {
        return body.velocity.y < -1;
    }
}