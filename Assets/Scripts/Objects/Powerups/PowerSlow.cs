using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSlow : PowerUp, IPowerUp
{
    public override IEnumerator Activate(Collider2D collision)
    {

        //slow down player & music
        collision.GetComponent<PlayerMovement>().speedModifier = 0.5f;
        GameObject.Find("Music").GetComponent<AudioSource>().pitch = 0.9f;
        collision.GetComponent<Animator>().speed *= 0.5f;

        yield return new WaitForSeconds(Duration);

        //reset values
        collision.GetComponent<PlayerMovement>().speedModifier = 1f;
        GameObject.Find("Music").GetComponent<AudioSource>().pitch = 1f;
        collision.GetComponent<Animator>().speed /= 0.5f;
    }
}
