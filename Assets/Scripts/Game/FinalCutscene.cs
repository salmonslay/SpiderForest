using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCutscene : MonoBehaviour
{
    [SerializeField] private AudioClip final;
    [SerializeField] private AudioClip credits;
    [SerializeField] private Camera cam;
    [SerializeField] private BeatPulse pulse;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        VisualNovel.Play("kap5");

        StartCoroutine(StartCutscene());
    }

    private IEnumerator StartCutscene()
    {
        yield return new WaitForSeconds(0.001f);
        GetComponent<Animator>().Play("Cutscene", 0, 0);
        Destroy(GameObject.Find("FinalMusic"));
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.Find("AmbienceManager"));
        Destroy(GameObject.Find("Canvas"));

        //switch camera
        cam.gameObject.SetActive(true);
        Destroy(Camera.main.gameObject);

        //play boss music
        Helper.PlayAudio(final).volume = 0.3f;

        //start credits
        yield return new WaitForSeconds(18f);

        Helper.PlayAudio(credits);

        yield return new WaitForSeconds(38.5f);

        pulse.enabled = true;
        Destroy(GetComponent<Animator>());
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("Main");
    }
}