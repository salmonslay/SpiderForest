using UnityEngine;

public class EnemyKilling : MonoBehaviour
{
    public Enemy enemy;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerMovement player = collider.GetComponent<PlayerMovement>();
            if (player.IsFalling()) enemy.Kill();
        }
    }
}