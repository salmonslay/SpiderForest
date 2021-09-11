using System.Collections;
using UnityEngine;

public interface IPowerUp
{
    /// <summary>
    /// Activates this power up
    /// </summary>
    public IEnumerator Activate(Collider2D collision);
}