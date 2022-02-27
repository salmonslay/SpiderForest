using UnityEngine;

public class VN_Trigger : MonoBehaviour
{

    private bool isPlayed = false;
    [Tooltip("ID of the visual novel to play on TriggerEnter")]
    [SerializeField] private string ID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isPlayed)
        {
            VisualNovel.Play(ID);
        }
        else return;

        isPlayed = true;
    }
    

    

}