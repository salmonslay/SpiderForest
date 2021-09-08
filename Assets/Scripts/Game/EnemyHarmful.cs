using UnityEngine;

public class EnemyHarmful : MonoBehaviour
{
    public int damage = 1;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerState state = collision.gameObject.GetComponent<PlayerState>();
            state.Harm(damage);
            enemy.ChangeDirection();
        }
    }
}