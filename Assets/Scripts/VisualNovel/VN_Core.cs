using UnityEngine;

public class VN_Core : MonoBehaviour
{
    [Tooltip("ID of the story text file.")]
    public string ID;

    private void Start()
    {
        VisualNovel.FreezeScene();
    }
}