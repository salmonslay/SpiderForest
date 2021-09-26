using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Level level;
    public Quest questCondition;
    public GameObject openState;
    public GameObject closedState;
    private bool isOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOpen)
        {
            //maybe play some cutscene?

            SceneManager.LoadScene(level.ID);
        }
    }

    private void Update()
    {
        SetState(questCondition.IsCompletedHere);
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