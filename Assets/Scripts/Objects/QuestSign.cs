using UnityEngine;
using UnityEngine.UI;

public class QuestSign : MonoBehaviour
{
    /// <summary>
    /// Animator of text to change
    /// </summary>
    [SerializeField] private GameObject textObj;

    private Text text;

    [SerializeField] private Quest quest;

    private void Start()
    {
        textObj.SetActive(false);
        text = textObj.GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textObj.SetActive(true);
        text.text = quest.QuestDescription;
        textObj.GetComponent<Animator>().Play("quest_popUp", 0, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textObj.GetComponent<Animator>().Play("quest_popOut", 0, 0);
    }
}