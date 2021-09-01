using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public float movementDirection = 1f;
    public Transform groundCheck;
    private Rigidbody2D body;
    public bool isAlive = true;
    private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        bool isGrounded = TouchesGround();
        animator.SetBool("IsAlive", isAlive);
        animator.SetBool("IsGrounded", isGrounded);

        if (isAlive)
        {
            Vector3 moveBy = Vector3.zero;
            moveBy.x = speed * Time.deltaTime * movementDirection;
            transform.Translate(moveBy);

            if (!isGrounded) ChangeDirection();
        }
    }

    /// <summary>
    /// Checks whether the enemy collides with another collider.
    /// </summary>
    private bool TouchesGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject) return true;
        }
        return false;
    }

    /// <summary>
    /// Change scale and movement direction of enemy
    /// </summary>
    public void ChangeDirection()
    {
        movementDirection *= -1;
        transform.localScale = new Vector3(movementDirection, 1f);
    }

    /// <summary>
    /// Kill this enemy
    /// </summary>
    public void Kill()
    {
        isAlive = false;
        GetComponent<BoxCollider2D>().isTrigger = true;
        body.AddForce(new Vector2(movementDirection, 4f), ForceMode2D.Impulse);
    }
}