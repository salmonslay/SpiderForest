using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Slider HP;

    private void Start()
    {
        Instance = this;
    }
}