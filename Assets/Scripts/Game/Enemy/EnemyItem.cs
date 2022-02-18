using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItem : MonoBehaviour
{
    //saker som slängs av poltergeist
    public Sprite[] EnemyItems;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = EnemyItems[Random.Range(0, EnemyItems.Length)];
    }

    //kopierat från EnemyMovingPoints
    internal void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            return;
        }
        // if enemy hits a player - do harm
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerState state = collision.gameObject.GetComponent<PlayerState>();
            state.Harm(1);
        }
        //ta bort
        Destroy(gameObject);
    }
}
