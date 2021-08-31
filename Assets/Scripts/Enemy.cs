using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public float movementDirection = 1f;
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
        Vector3 moveBy = Vector3.zero;
        moveBy.x = speed * Time.deltaTime * movementDirection;
        transform.Translate(moveBy);

        if (!TouchesGround()) ChangeDirection();
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
    private void ChangeDirection()
    {
        movementDirection *= -1;
        transform.localScale = new Vector3(movementDirection, 1f);
    }
}