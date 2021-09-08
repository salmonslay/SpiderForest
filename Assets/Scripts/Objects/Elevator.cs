using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform[] nodes;
    private int targetIndex = 0;
    public float speed = 5f;

    private void FixedUpdate()
    {
        Vector3 target = nodes[targetIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, target, 5 * Time.fixedDeltaTime);
        if (transform.position == target)
        {
            if (++targetIndex == nodes.Length) targetIndex = 0;
        }
    }

    /// <summary>
    /// Hook player to elevator for smoother movements
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform col = collision.transform;
        if (col.CompareTag("Player"))
            col.SetParent(transform);
    }

    /// <summary>
    /// Unhook player when they leave the elevator
    /// </summary>
    private void OnTriggerExit2D(Collider2D collision)
    {
        Transform col = collision.transform;
        if (col.CompareTag("Player"))
            col.parent = null;
    }
}