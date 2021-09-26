using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script for enemies that will move between points (elevator-like)
/// </summary>
public class EnemyMovingPoints : Enemy
{
    private List<Vector3> points = new List<Vector3>();
    private int targetIndex = 0;

    private new SpriteRenderer renderer;

    public float speed = 5f;

    [SerializeField] private Sprite canSeePlayer;
    [SerializeField] private Sprite lostInDarkness;

    private PlayerMovement player;

    public override void Start()
    {
        //run Start() on base class
        base.Start();

        renderer = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerMovement>();

        // add all child gameobjects named "point" to pointlist
        foreach (Transform t in transform.parent.GetComponentsInChildren<Transform>())
        {
            if (t.name.ToLower().Contains("point"))
            {
                Vector3 pos = new Vector3(t.position.x, t.position.y, 0);
                points.Add(pos);
            }
        }
    }

    private void Update()
    {
        Vector3 target = points[targetIndex];
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //set rotation
        renderer.flipX = transform.position.x < target.x;

        //update target
        if (transform.position == target)
        {
            if (++targetIndex == points.Count) targetIndex = 0;
        }

        //set sprite
        renderer.sprite = player.isFlashlightOn ? canSeePlayer : lostInDarkness;
        renderer.color = player.isFlashlightOn ? new Color(1, 1, 1, 0.5f) : Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if enemy hits a player - do harm
        if (collision.gameObject.CompareTag("Player"))
        {
            // do harm if flashlight is enabled or else check a 25% risk
            if (collision.GetComponent<PlayerMovement>().isFlashlightOn || Random.Range(0, 5) == 2)
            {
                PlayerState state = collision.gameObject.GetComponent<PlayerState>();
                state.Harm(damage);
            }
        }
    }
}