using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSprite : MonoBehaviour
{
    public SpriteRenderer sprite;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            StartCoroutine(FlashRed());
        }
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }
}
