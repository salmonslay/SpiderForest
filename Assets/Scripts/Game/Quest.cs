using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public static List<Quest> Quests = new List<Quest>();

    [Tooltip("The level this quest will permanently unlock upon completion.")]
    public Level levelToUnlock;

    [Tooltip("Key for increasing this quest. For example, picking up a coin will increment all quests with the condition \"collect_coins\"")]
    public string condition = "";

    public float NeededAmount = 0;
    public float CurrentAmount = 0;
    [SerializeField] private string _questDescription = "Collect @ coins";
    [SerializeField] private string _completionDescription = "Nice";

    /// <summary>
    /// Gets a quest description depending on the current completion status
    /// </summary>
    public string QuestDescription
    {
        get
        {
            if (IsCompletedHere)
                return _completionDescription;
            else
                return _questDescription.Replace("@", $"{CurrentAmount}/{NeededAmount}");
        }
    }

    /// <summary>
    /// Checks if this quest have been completed during THIS session / attempt
    /// </summary>
    public bool IsCompletedHere
    {
        get
        {
            return CurrentAmount >= NeededAmount;
        }
    }

    /// <summary>
    /// Checks if this quest ever have been completed
    /// </summary>
    public bool IsCompletedOnce
    {
        get
        {
            return PlayerPrefs.GetInt(levelToUnlock.CompletionKey, 0) == 1;
        }
    }

    private void Start()
    {
        Quests.Clear();
        Quests.Add(this);
    }

    /// <summary>
    /// Increase this quest objective
    /// </summary>
    /// <param name="amount">Amount to increase objective by</param>
    public void Increase(float amount = 1.0f)
    {
        CurrentAmount += amount;

        // save global completion
        if (IsCompletedHere) SaveCompletion();
    }

    /// <summary>
    /// Saves this quest as completed in PlayerPrefs
    /// </summary>
    public void SaveCompletion()
    {
        PlayerPrefs.SetInt(levelToUnlock.CompletionKey, 1);
    }

    #region static methods

    /// <summary>
    /// Search for quest by condition
    /// </summary>
    /// <param name="query">Quest condition to search for</param>
    /// <returns>First quest with matching condition, or null if none is found</returns>
    public static Quest Get(string query)
    {
        foreach (Quest q in Quests) if (q.condition == query.ToLower())
                return q;
        return null;
    }

    /// <summary>
    /// Search for quest by condition and increase it if found
    /// </summary>
    /// <param name="ID">Quest condition to search for</param>
    /// <param name="amount">Amount to increase objective by</param>
    public static void Increase(string condition, float amount = 1.0f)
    {
        Quest quest = Get(condition);
        if (quest) quest.Increase(amount);
    }

    #endregion static methods
}