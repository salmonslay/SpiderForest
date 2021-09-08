using UnityEngine;
using UnityEngine.UI;

public class BeatPulse : MonoBehaviour
{
    [SerializeField] private float BPM;

    [SerializeField] private GameObject ray;
    [SerializeField] private float raySpeed = 30;

    [SerializeField] private float logoSize = 1.055f;
    [SerializeField] private Color logoColor;

    private void Update()
    {
        var baseValue = Mathf.Cos(Time.time * Mathf.PI * (BPM / 60f) % Mathf.PI);
        transform.localScale = Vector3.Lerp(new Vector3(1f, 1f, 1), new Vector2(logoSize, logoSize), baseValue);
        GetComponent<Image>().color = Color.Lerp(Color.white, logoColor, baseValue);

        //spin rays
        ray.transform.Rotate(0, 0, 30 * Time.deltaTime * (Mathf.Abs(baseValue) + 1));
    }
}