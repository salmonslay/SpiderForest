using UnityEngine;

public class WaterBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            Destroy(collision.gameObject, 0.5f);
        else if (collision.CompareTag("Player"))
            collision.GetComponent<PlayerState>().Spawn();
    }
}