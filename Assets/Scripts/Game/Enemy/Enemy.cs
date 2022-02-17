using UnityEngine;

/// <summary>
/// Base class for all enemies.
/// </summary>
public class Enemy : MonoBehaviour
{
    [HideInInspector] public bool isAlive = true;
    [HideInInspector] public Rigidbody2D body;
    [HideInInspector] public float movementDirection = 1f;

    [Tooltip("Damage this enemy will do on direct impact")]
    public int damage;

    public virtual void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Kill this enemy.
    /// Applies force and removes collision.
    /// </summary>
    public void Kill()
    {
        print("im dead");
        isAlive = false;
        GetComponent<BoxCollider2D>().isTrigger = true;
        body.AddForce(new Vector2(movementDirection, 4f), ForceMode2D.Impulse);
    }
}