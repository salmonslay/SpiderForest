using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "platform!/Level", order = 1)]
[Serializable]
public class Level : ScriptableObject
{
    [Tooltip("ID used to load this level")]
    public string ID;

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

    public bool Unlocked
    {
        get
        {
            return PlayerPrefs.GetInt(CompletionKey, 0) == 1;
        }
    }
}