using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private void Awake()
    {
        if (!GameObject.Find("Music"))
        {
            print("starting music");
            GameObject music = new GameObject("Music");
            DontDestroyOnLoad(music);
            AudioSource source = music.AddComponent<AudioSource>();
            source.clip = Resources.Load<AudioClip>("LevelMusic");
            source.loop = true;
            source.volume = 0.3f;
            source.Play();
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "Main")
                Destroy(gameObject);
        }
    }
}