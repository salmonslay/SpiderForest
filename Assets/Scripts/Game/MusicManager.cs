using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private void Awake()
    {
        if (!GameObject.Find("Music") && SceneManager.GetActiveScene().name != "Room3_Fabian")
        {
            GameObject music = new GameObject("Music");
            DontDestroyOnLoad(music);
            AudioSource source = music.AddComponent<AudioSource>();
            source.clip = Resources.Load<AudioClip>("LevelMusic");
            source.loop = true;
            source.volume = 0.15f;
            source.Play();
        }
        if (SceneManager.GetActiveScene().name == "Main" || SceneManager.GetActiveScene().name == "Room3_Fabian")
            Destroy(GameObject.Find("Music"));
    }
}