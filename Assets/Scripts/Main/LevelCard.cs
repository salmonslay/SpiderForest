using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCard : MonoBehaviour
{
    public string ID;
    public Text levelName;
    public Text levelDescription;
    public Image levelIcon;

    public void Load()
    {
        SceneManager.LoadScene(ID);
    }
}