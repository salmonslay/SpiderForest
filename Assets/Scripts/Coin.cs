using UnityEngine;

public class Coin : MonoBehaviour
{
    /// <summary>
    /// Total coins picked up during this level
    /// </summary>
    public static int PickedUp = 0;

    private void Start()
    {
        PickedUp = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //play audio
            GetComponent<AudioSource>().pitch = 1 + ((float)PickedUp++ / 30);
            GetComponent<AudioSource>().Play();

            collision.GetComponent<PlayerState>().PickCoin(1);

            //destroy coin
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            Destroy(gameObject, 10);
        }
    }
}