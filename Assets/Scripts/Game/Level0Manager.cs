using UnityEngine;

/// <summary>
/// Manages cutscenes and stuff for level 0
/// </summary>
public class Level0Manager : MonoBehaviour
{
    public static State state = State.NeverPlayed;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Level level1;

    private void Awake()
    {
        //spawn inside house instead
        if (state != State.NeverPlayed)
        {
            spawnPoint.localPosition = new Vector3(68f, 3, 0);
        }

        if (state == State.NeverPlayed) VisualNovel.Play("kap1");
        if (state == State.Completed1) VisualNovel.Play("kap3");
        if (state == State.Completed2) VisualNovel.Play("kap4");
    }

    public enum State
    {
        NeverPlayed, //play chap1 at start - chap2 at house eter
        Completed1, //play chap3
        Completed2, //play chap4
        Completed //just spawn player further in
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && state == State.NeverPlayed)
        {
            PlayerPrefs.SetInt(level1.CompletionKey, 1);
            VisualNovel.Play("kap2");
            state = State.Completed;
        }
    }
}