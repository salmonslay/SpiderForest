using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    /// <summary>
    /// Change direction if enemy hits something that isn't player
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy.ChangeDirection();
    }
}