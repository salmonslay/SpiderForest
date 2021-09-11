using System.Collections;
using UnityEngine;

public class PowerSpeed : PowerUp, IPowerUp
{
    public override IEnumerator Activate(Collider2D collision)
    {
        StartCoroutine(base.Activate(collision));
        collision.GetComponent<PlayerMovement>().speedModifier = 1.5f;
        GameObject.Find("Music").GetComponent<AudioSource>().pitch = 1.1f;
        yield return new WaitForSeconds(Duration);
        collision.GetComponent<PlayerMovement>().speedModifier = 1f;
        GameObject.Find("Music").GetComponent<AudioSource>().pitch = 1f;
    }
}