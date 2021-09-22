using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script for enemies that will move between points (elevator-like)
/// </summary>
public class EnemyMovingPoints : Enemy
{
    private List<Vector3> points = new List<Vector3>();
    private int targetIndex = 0;

    public float speed = 5f;

    public override void Start()
    {
        //run Start() on base class
        base.Start();

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
        transform.position = Vector2.MoveTowards(transform.position, target, 5 * Time.deltaTime);
        if (transform.position == target)
        {
            if (++targetIndex == points.Count) targetIndex = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("o");
        // if enemy hits a player - do harm
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerState state = collision.gameObject.GetComponent<PlayerState>();
            state.Harm(damage);
        }
    }
}