using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Level", menuName = "platform!/Level", order = 1)]
[Serializable]
public class Level : ScriptableObject
{
    [Tooltip("ID used to load this level")]
    public string ID;

    [Tooltip("Level name shown in menu")]
    public string levelName;

    [Tooltip("Level description shown in menu")]
    public string levelDescription;

    [Tooltip("Level icon shown in menu")]
    public Image levelIcon;
}