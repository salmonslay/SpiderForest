using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    /// <summary>
    /// Total coins picked up during this level
    /// </summary>
    public static int PickedUp = 0;

    /// <summary>
    /// Last time user picked up a coin
    /// </summary>
    private static DateTime LastPickup = DateTime.MinValue;

    private void Update()
    {
        //Reset pitch if user has not picked up coins for 3 seconds
        if ((DateTime.Now - LastPickup).TotalSeconds > 3)
            PickedUp = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //play audio
            GetComponent<AudioSource>().pitch = 1 + ((float)PickedUp++ / 30);
            GetComponent<AudioSource>().Play();
            LastPickup = DateTime.Now;

            //add coins
            collision.GetComponent<PlayerState>().PickCoin(1);

            //destroy coin
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            Destroy(gameObject, 10);
        }
    }
}