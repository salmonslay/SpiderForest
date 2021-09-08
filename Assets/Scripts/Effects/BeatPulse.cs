using UnityEngine;
using UnityEngine.UI;

public class BeatPulse : MonoBehaviour
{
    [SerializeField] private float BPM;
    [SerializeField] private float size = 1.055f;
    [SerializeField] private GameObject ray;
    [SerializeField] private Color logoColor;

    private void Update()
    {
        var baseValue = Mathf.Cos(Time.time * Mathf.PI * (BPM / 60f) % Mathf.PI);
        ray.transform.Rotate(0, 0, 30 * Time.deltaTime);
        this.transform.localScale = Vector3.Lerp(new Vector3(1f, 1f, 1), new Vector3(size, size, 1), baseValue);
        this.GetComponent<Image>().color = Color.Lerp(Color.white, logoColor, baseValue);
    }
}