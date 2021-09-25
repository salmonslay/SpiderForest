using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform[] nodes;
    private int targetIndex = 0;
    public float speed = 5f;

    private void Start()
    {
        // change all node positions to Z=0 to prevent hidden delays
        for (int i = 0; i < nodes.Length; i++)
        {
            nodes[i].localPosition = new Vector3(nodes[i].localPosition.x, nodes[i].localPosition.y, 0);
        }
    }

    private void Update()
    {
        Vector3 target = nodes[targetIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, target, 5 * Time.deltaTime);
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, nodes[0].position);
        for (int i = 0; i < nodes.Length - 1; i++)
        {
            Gizmos.DrawLine(nodes[i].position, nodes[i + 1].position);
        }
        Gizmos.DrawLine(nodes[nodes.Length - 1].position, transform.position);
    }
}