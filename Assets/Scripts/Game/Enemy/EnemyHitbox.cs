using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    /// <summary>
    /// This enemy is set from its parent
    /// </summary>
    [HideInInspector] public Enemy enemy;

    public AudioClip EnemyKillSound;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerMovement player = collider.GetComponent<PlayerMovement>();
            if (player.IsFalling())
            {

                enemy.Kill();

                Helper.PlayAudio(EnemyKillSound);
            }
        }
    }
}