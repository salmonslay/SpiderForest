using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("New checkpoint set.");
            collision.GetComponent<PlayerState>().respawnPosition = transform.position;
            GetComponent<Animator>().enabled = true;
        }
    }
}