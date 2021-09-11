using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour, IPowerUp
{
    /// <summary>
    /// A name for this power up
    /// </summary>
    [SerializeField] public string Name;

    /// <summary>
    /// Icon shown in UI and in-game
    /// </summary>
    private Sprite icon;

    /// <summary>
    /// Duration for this power up to run
    /// </summary>
    public float Duration;

    /// <summary>
    /// Position this item originally spawned at
    /// </summary>
    private Vector3 pos;

    private ParticleSystem.EmissionModule particleEmission;
    private ParticleSystem.MainModule particleMain;

    private void Start()
    {
        icon = GetComponent<SpriteRenderer>().sprite;
        particleMain = GetComponent<ParticleSystem>().main;
        particleEmission = GetComponent<ParticleSystem>().emission;

        pos = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(pos.x, Mathf.Sin(Time.time) * 0.25f + pos.y, pos.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Activate(collision));
        }
    }

    public virtual IEnumerator Activate(Collider2D collision)
    {
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(GetComponent<SpriteRenderer>());
        particleMain.startSpeedMultiplier *= 5;
        particleMain.startLifetime = 1;
        particleEmission.rateOverTime = 1000;

        yield return new WaitForSeconds(0.1f);
        particleEmission.rateOverTime = 0;

        //wait for powerup to end
        yield return new WaitForSeconds(Duration - 0.1f);

        // todo: remove from UI
    }
}