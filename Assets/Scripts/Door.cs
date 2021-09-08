using UnityEngine;

public class Door : MonoBehaviour
{
    public Quest questCondition;
    public GameObject openState;
    public GameObject closedState;
    private bool isOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOpen)
        {
        }
    }

    private void Update()
    {
        SetState(questCondition.IsComplete);
    }

    /// <summary>
    /// Open or close this door
    /// </summary>
    /// <param name="open"></param>
    public void SetState(bool open)
    {
        isOpen = open;
        openState.SetActive(open);
        closedState.SetActive(!open);
    }
}