using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerJetpack : PowerUp, IPowerUp
{
    public override IEnumerator Activate(Collider2D collision)
    {
        StartCoroutine(base.Activate(collision));

        collision.GetComponent<Jetpack>().IsUnlocked = true;
        yield return null;
    }
}