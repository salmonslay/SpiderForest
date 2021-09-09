using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Text>().text = $"Coins taken: {PlayerPrefs.GetFloat(Keys.Coins.ToString(), 0)}\n" +
            $"Distance ran: {Mathf.RoundToInt(PlayerPrefs.GetFloat(Keys.MetersRan.ToString(), 0))} meters\n" +
            $"Times jumped: {PlayerPrefs.GetFloat(Keys.Jumps.ToString(), 0)}";
    }

    /// <summary>
    /// Increase statistic
    /// </summary>
    /// <param name="key">Stat to increase</param>
    /// <param name="amount">Amount to increase by</param>
    public static void Increase(Keys key, float amount = 1)
    {
        PlayerPrefs.SetFloat(key.ToString(), PlayerPrefs.GetFloat(key.ToString(), 0) + amount);
    }

    public enum Keys
    {
        Coins,
        MetersRan,
        Jumps
    }
}