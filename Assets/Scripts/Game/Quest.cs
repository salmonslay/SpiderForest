using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public static List<Quest> Quests = new List<Quest>();

    public string ID = "";
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
            if (IsComplete)
                return _completionDescription;
            else
                return _questDescription.Replace("@", $"{CurrentAmount}/{NeededAmount}");
        }
    }

    public bool IsComplete
    {
        get
        {
            return CurrentAmount >= NeededAmount;
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
    }

    #region static methods

    /// <summary>
    /// Search for quest by ID
    /// </summary>
    /// <param name="query">Quest ID to search for</param>
    /// <returns>First quest with matching ID, or null if none is found</returns>
    public static Quest Get(string query)
    {
        foreach (Quest q in Quests) if (q.ID == query.ToLower())
                return q;
        return null;
    }

    /// <summary>
    /// Search for quest by ID and increase it if found
    /// </summary>
    /// <param name="ID">Quest ID to search for</param>
    /// <param name="amount">Amount to increase objective by</param>
    public static void Increase(string ID, float amount = 1.0f)
    {
        Quest quest = Get(ID);
        if (quest) quest.Increase(amount);
    }

    #endregion static methods
}