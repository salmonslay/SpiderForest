using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Container for level cards used in the main menu.
/// </summary>
public class LevelCard : MonoBehaviour
{
    public string ID;
    public Text levelName;
    public Text levelDescription;
    public Image levelIcon;

    /// <summary>
    /// Loads scene
    /// </summary>
    public void Load()
    {
        SceneManager.LoadScene(ID);
    }
}