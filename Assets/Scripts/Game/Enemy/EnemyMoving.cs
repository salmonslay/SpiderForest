using UnityEngine;

/// <summary>
/// Base class for enemies that will move until they hit a collider or a slope.
/// </summary>
public class EnemyMoving : Enemy
{
    [Tooltip("Speed multiplier this enemy will move by")]
    [SerializeField] private float speed = 5f;

    [Tooltip("Whether or not this enemy should care if it touches the ground or not. Unchecking this will result in flying enemies.")]
    [SerializeField] private bool useGround = true;

    [Tooltip("Empty GameObject in front of enemy that decides if it's touching the ground or not.")]
    public Transform groundCheck;

    private Animator animator;
    private BoxCollider2D enemyCollider;
    private bool isGrounded = true;
    private EnemyHitbox hitbox;

    public override void Start()
    {
        //run Start() on base class
        base.Start();

        //get components
        animator = GetComponent<Animator>();
        enemyCollider = GetComponent<BoxCollider2D>();

        //set hitbox
        hitbox = GetComponentInChildren<EnemyHitbox>();
        if (hitbox)
            hitbox.enemy = this;

        //add trigger collider automatically to detect walls
        //this collider is 5% wider and 50% shorter than the original collider
        BoxCollider2D col = gameObject.AddComponent<BoxCollider2D>();
        col.size = new Vector2(enemyCollider.size.x * 1.05f, enemyCollider.size.y / 2f);
        col.offset = enemyCollider.offset;
        col.isTrigger = true;
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

            if (!isGrounded && useGround) SwapDirection();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if enemy hits a player - do harm
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerState state = collision.gameObject.GetComponent<PlayerState>();
            state.Harm(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // swap direction when enemy enters a trigger
        SwapDirection();
    }
}