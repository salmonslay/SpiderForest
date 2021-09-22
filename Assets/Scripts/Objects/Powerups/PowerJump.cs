using System.Collections;
using UnityEngine;

public class PowerJump : PowerUp, IPowerUp
{
    public override IEnumerator Activate(Collider2D collision)
    {
        StartCoroutine(base.Activate(collision));

        //speed up player & music
        collision.GetComponent<PlayerMovement>().jumpForce *= 1.5f;

        yield return new WaitForSeconds(Duration);

        //reset values
        collision.GetComponent<PlayerMovement>().jumpForce /= 1.5f;
    }
}