using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerShoot : PowerUp, IPowerUp
{
    public override IEnumerator Activate(Collider2D collision)
    {
        StartCoroutine(base.Activate(collision));

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
        player.canShoot = true;

        yield return null;
    }
}
