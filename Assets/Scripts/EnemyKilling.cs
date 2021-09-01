using UnityEngine;

public class EnemyKilling : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}