using System.Collections;
using UnityEngine;

/// <summary>
/// Base class for all power ups in the game.
/// </summary>
public class PowerUp : MonoBehaviour, IPowerUp
{
    [Tooltip("A name for this power up")]
    [SerializeField] public string Name;

    [Tooltip("Icon shown in UI and in-game")]
    private Sprite icon;

    [Tooltip("Duration for this power up to run")]
    public float Duration;

    [SerializeField] private AudioClip powerup;
    [SerializeField] private AudioClip powerdown;

    [Tooltip("Position this item originally spawned at")]
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
        // pick up power up
        Helper.PlayAudio(powerup);
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(GetComponent<SpriteRenderer>());
        StartCoroutine(Deactivate(collision));

        // add to UI
        StartCoroutine(UIManager.Instance.AddPower(icon, Duration));

        // play particle burst
        particleMain.startSpeedMultiplier *= 5;
        particleMain.startLifetime = 1;
        particleEmission.rateOverTime = 1000;
        yield return new WaitForSeconds(0.1f);
        particleEmission.rateOverTime = 0;
    }

    public virtual IEnumerator Deactivate(Collider2D collision)
    {
        yield return new WaitForSeconds(Duration);
        Helper.PlayAudio(powerdown);
    }
}