using UnityEngine;

public class VisualNovel : MonoBehaviour
{
    /// <summary>
    /// Start playing a visual novel.
    /// </summary>
    /// <param name="ID">ID of the story to play</param>
    /// <returns>The VN instance.</returns>
    public static GameObject Play(string ID)
    {
        GameObject instance = Instantiate(Resources.Load("VisualNovel/Prefabs/_Canvas")) as GameObject;
        instance.GetComponent<VN_Core>().ID = ID;
        return instance;
    }

    /// <summary>
    /// Freeze this scene
    /// </summary>
    public static void FreezeScene()
    {
        IsPlaying = true;
        GameObject music = GameObject.Find("Music");
        if (music)
        {
            music.GetComponent<AudioSource>().Pause();
        }
        Time.timeScale = 0;
    }

    /// <summary>
    /// Keep playing this scene after VN is done.
    /// </summary>
    public static void ContinueScene()
    {
        IsPlaying = false;
        GameObject music = GameObject.Find("Music");
        if (music)
        {
            music.GetComponent<AudioSource>().Play();
        }
        Time.timeScale = 1;
    }

    public static bool IsPlaying = false;
}