using UnityEngine;

public class Helper : MonoBehaviour
{
    /// <summary>
    /// Creates a new audio source and plays a clip on it
    /// </summary>
    /// <param name="clip">Audio clip to play</param>
    public static AudioSource PlayAudio(AudioClip clip)
    {
        GameObject audio = new GameObject();
        AudioSource source = audio.AddComponent<AudioSource>();
        source.clip = clip;
        source.Play();
        return source;
    }
}