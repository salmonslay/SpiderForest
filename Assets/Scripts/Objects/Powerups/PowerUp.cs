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
    private Sprite Icon;

    /// <summary>
    /// Color for this power ups particles
    /// </summary>
    public Color ParticleColor;

    /// <summary>
    /// Duration for this power up to run
    /// </summary>
    public float Duration;

    /// <summary>
    /// Position this item originally spawned at
    /// </summary>
    private Vector3 pos;

    private void Start()
    {
        Icon = GetComponent<SpriteRenderer>().sprite;
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

        // todo: add icon to UI

        //wait for powerup to end
        yield return new WaitForSeconds(Duration);

        // todo: remove from UI
    }
}