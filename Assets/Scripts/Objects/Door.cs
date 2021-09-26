using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Level level;
    public Quest questCondition;
    public GameObject openState;
    public GameObject closedState;
    private bool isOpen = false;
    public bool forceOpen = false;

    [SerializeField] private Level0Manager.State state;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOpen)
        {
            Level0Manager.state = state;
            SceneManager.LoadScene(level.ID);
        }
    }

    private void Update()
    {
        SetState(questCondition.IsCompletedHere || forceOpen);
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