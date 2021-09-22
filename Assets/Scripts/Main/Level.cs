using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Level", menuName = "platform!/Level", order = 1)]
[Serializable]
public class Level : ScriptableObject
{
    [Tooltip("ID used to load this level")]
    [SerializeField] private Scene scene;

    [Tooltip("Level name shown in main menu")]
    public string levelName;

    [Tooltip("Level description shown in main menu")]
    public string levelDescription;

    [Tooltip("Level icon shown in main menu")]
    public Sprite levelIcon;

    public string CompletionKey
    {
        get
        {
            return "COMPLETED_" + ID;
        }
    }

    public string ID
    {
        get
        {
            return scene.name;
        }
    }

    public bool Unlocked
    {
        get
        {
            return PlayerPrefs.GetInt(CompletionKey, 0) == 1;
        }
    }
}