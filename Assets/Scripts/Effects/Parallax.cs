using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Vector3 StartPos;
    [SerializeField] private float moveModifier;

    private void Start()
    {
        StartPos = transform.position;
    }

    private void Update()
    {
        Vector3 pz = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        pz.z = 0;
        gameObject.transform.position = pz;

        transform.position = new Vector3(StartPos.x + (pz.x * moveModifier), StartPos.y + (pz.y * moveModifier), 0);
    }
}