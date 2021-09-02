using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [HideInInspector]
    public static UIManager Instance;

    public Text Coins;
    public Slider HP;

    private void Start()
    {
        Instance = this;
    }
}