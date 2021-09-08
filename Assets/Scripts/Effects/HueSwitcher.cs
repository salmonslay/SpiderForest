using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Cycles through the hue value of the image sharing this component
/// </summary>
public class HueSwitcher : MonoBehaviour
{
    private Image img;
    [SerializeField] private float speed = 0.25f;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    private void Update()
    {
        Color.RGBToHSV(img.color, out float h, out float s, out float v);
        img.color = Color.HSVToRGB(h + Time.deltaTime * speed, s, v);
    }
}