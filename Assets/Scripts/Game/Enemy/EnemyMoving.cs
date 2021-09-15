using UnityEngine;

/// <summary>
/// Base class for enemies that will move until they hit a collider or a slope.
/// </summary>
public class EnemyMoving : Enemy
{
    [SerializeField] private float speed = 5f;
    public Transform groundCheck;
    private Animator animator;
    private bool isGrounded = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = TouchesGround();
        animator.SetBool("IsAlive", isAlive);
        animator.SetBool("IsGrounded", isGrounded);

        if (isAlive)
        {
            Vector3 moveBy = Vector3.zero;
            moveBy.x = speed * Time.deltaTime * movementDirection;
            transform.Translate(moveBy);

            if (!isGrounded) SwapDirection();
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
            if (collider.gameObject != gameObject && !collider.isTrigger) return true;
        }
        return false;
    }

    /// <summary>
    /// Change scale and movement direction of enemy
    /// </summary>
    public void SwapDirection()
    {
        movementDirection *= -1;
        transform.localScale = new Vector3(movementDirection, 1f);
    }
}