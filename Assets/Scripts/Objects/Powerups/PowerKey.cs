using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerKey : PowerUp, IPowerUp
{
    [Tooltip("The level this key will unlock")]
    [SerializeField] private Level LevelToUnlock;

    public override IEnumerator Activate(Collider2D collision)
    {
        StartCoroutine(base.Activate(collision));

        print($"Level {LevelToUnlock.ID} unlocked by key.");
        PlayerPrefs.SetInt(LevelToUnlock.CompletionKey, 1);
        yield return null;
    }
}
