using System.Collections;
using UnityEngine;

public class Ambience : MonoBehaviour
{
    public AudioClip[] ambience;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        Invoke("StartLoop", 9f);
    }

    private void StartLoop()
    {
        StartCoroutine(PlayAudio());
    }

    private IEnumerator PlayAudio()
    {
        if (Random.Range(0, 2) == 0) source.panStereo = Random.Range(-1, -0.8f);
        else source.panStereo = Random.Range(1, 0.8f);

        source.clip = GetClip();
        source.Play();

        yield return new WaitForSecondsRealtime(source.clip.length + Random.Range(3, 12f));
        StartCoroutine(PlayAudio());
    }

    private AudioClip GetClip()
    {
        return ambience[Random.Range(0, ambience.Length)];
    }
}