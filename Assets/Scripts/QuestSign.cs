using UnityEngine;

public class QuestSign : MonoBehaviour
{
    /// <summary>
    /// Animator of text to change
    /// </summary>
    [SerializeField] private Animator textAnimator;

    private void Start()
    {
        textAnimator.transform.localScale = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textAnimator.Play("quest_popUp", 0, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textAnimator.Play("quest_popOut", 0, 0);
    }
}