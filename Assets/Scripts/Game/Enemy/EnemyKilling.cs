using UnityEngine;

public class EnemyKilling : MonoBehaviour
{
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerMovement player = collider.GetComponent<PlayerMovement>();
            if (player.IsFalling()) enemy.Kill();
        }
    }
}