using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 2.5f;
    public Transform groundCheck;
    private Rigidbody2D body;

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        bool isGrounded = false;
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag != "Player")
            {
                isGrounded = true; break;
            }
        }

        Vector3 moveBy = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(moveBy * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            body.AddForce(new Vector2(0, jumpForce * 100));
    }
}