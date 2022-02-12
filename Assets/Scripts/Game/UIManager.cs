using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Public instance of the UI manager, allowing other scripts to access it easily.
    /// </summary>
    [HideInInspector]
    public static UIManager Instance;

    public Text Coins;
    public Image HP;
    public Transform PowerUpHolder;
    public Image JetpackFuel;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Add a power up to the UI, and then deletes it when the duration is over
    /// </summary>
    /// <param name="sprite">Sprite to add</param>
    /// <param name="delay">Duration the power up lasts</param>
    public IEnumerator AddPower(Sprite sprite, float delay)
    {
        GameObject g = new GameObject();
        Image renderer = g.AddComponent<Image>();

        g.transform.SetParent(PowerUpHolder);
        renderer.sprite = sprite;

        yield return new WaitForSeconds(delay);

        Destroy(g);
    }
}