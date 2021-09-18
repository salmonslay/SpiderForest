using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour
{
    [Tooltip("Level this door will lead to upon interacting with it")]
    [SerializeField] private Level level;

    [Tooltip("Whether the player is touching this door or not")]
    private bool isPlayerTouching = false;

    [Tooltip("Audio clip to play when user tries to enter locked door")]
    [SerializeField] private AudioClip lockedAudio;

    [Tooltip("Parent for the closed door, disabled when this door is usable.")]
    [SerializeField] private GameObject doorClosed;

    private void Start()
    {
        if (level.Unlocked)
        {
            doorClosed.SetActive(false);
        }
    }

    private void Update()
    {
        // handle interactions
        if (Input.GetKeyDown(KeyCode.E) && isPlayerTouching)
        {
            // try to go to a level (through this door)
            if (level.Unlocked)
                Enter();
            else
                ShakeDoor();
        }
    }

    /// <summary>
    /// Open this door and go to the level/room in question
    /// </summary>
    private void Enter()
    {
        SceneManager.LoadScene(level.ID);
    }

    /// <summary>
    /// Try to open this door but realize you can't.
    /// So... you shake it instead :D right?
    /// </summary>
    private void ShakeDoor()
    {
        Helper.PlayAudio(lockedAudio);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) isPlayerTouching = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) isPlayerTouching = false;
    }
}