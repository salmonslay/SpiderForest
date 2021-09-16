using UnityEngine;
using UnityEngine.UI;

public class QuestSign : MonoBehaviour
{
    /// <summary>
    /// Animator of text to change
    /// </summary>
    [SerializeField] private GameObject textObj;

    /// <summary>
    /// Exclamation mark to hover while quest is not complete
    /// </summary>
    [SerializeField] private Transform exclamationMark;

    private Vector3 exclamationMarkPos;

    private Text text;

    [SerializeField] private Quest quest;

    private void Start()
    {
        textObj.SetActive(false);
        exclamationMark.gameObject.SetActive(true);

        exclamationMarkPos = exclamationMark.position;
        text = textObj.GetComponent<Text>();
    }

    private void Update()
    {
        exclamationMark.position = new Vector3(exclamationMarkPos.x, Mathf.Sin(Time.time) * 0.25f + exclamationMarkPos.y, exclamationMarkPos.z);
        if (quest.IsCompletedHere) exclamationMark.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textObj.SetActive(true);
        exclamationMark.gameObject.SetActive(false);
        text.text = quest.QuestDescription;
        textObj.GetComponent<Animator>().Play("quest_popUp", 0, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        exclamationMark.gameObject.SetActive(!quest.IsCompletedHere);
        textObj.GetComponent<Animator>().Play("quest_popOut", 0, 0);
    }
}