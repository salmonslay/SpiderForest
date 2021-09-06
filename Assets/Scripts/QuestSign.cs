using UnityEngine;

public class QuestSign : MonoBehaviour
{
    /// <summary>
    /// Animator of text to change
    /// </summary>
    [SerializeField] private Animator textAnimator;

    private void Start()
    {
        textAnimator.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textAnimator.gameObject.SetActive(true);
        textAnimator.Play("quest_popUp", 0, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textAnimator.Play("quest_popOut", 0, 0);
    }
}