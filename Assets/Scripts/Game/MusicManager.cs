using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private void Start()
    {
        if (!GameObject.Find("Music"))
        {
            print("starting music");
            GameObject music = new GameObject("Music");
            DontDestroyOnLoad(music);
            AudioSource source = music.AddComponent<AudioSource>();
            source.clip = Resources.Load<AudioClip>("LevelMusic");
            source.Play();
            source.loop = true;
        }
        else if (SceneManager.GetActiveScene().name == "Main")
        {
            Destroy(gameObject);
        }
    }
}