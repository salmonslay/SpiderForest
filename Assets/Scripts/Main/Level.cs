using System;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "platform!/Level", order = 1)]
[Serializable]
public class Level : ScriptableObject
{
    [Tooltip("ID used to load this level")]
    [SerializeField] private SceneAsset scene;

    [Tooltip("Level name shown in main menu")]
    public string levelName;

    [Tooltip("Level description shown in main menu")]
    public string levelDescription;

    [Tooltip("Level icon shown in main menu")]
    public Sprite levelIcon;

    [Tooltip("Whether this level always should be open")]
    [SerializeField] private bool alwaysUnlocked = false;

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
            return PlayerPrefs.GetInt(CompletionKey, 0) == 1 || alwaysUnlocked;
        }
    }
}