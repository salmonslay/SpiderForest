using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [HideInInspector]
    public static UIManager Instance;

    public Text Coins;
    public Slider HP;
    public Transform PowerUpHolder;

    private void Awake()
    {
        Instance = this;
    }

    public IEnumerator AddPower(Sprite sprite, float delay)
    {
        GameObject g = new GameObject();
        Image renderer = g.AddComponent<Image>();

        g.transform.parent = PowerUpHolder;
        renderer.sprite = sprite;

        yield return new WaitForSeconds(delay);

        Destroy(g);
    }
}