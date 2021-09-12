using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Transform target;
    public Vector3 offset = new Vector3(6, 0, -10);
    public float smoothSpeed = 0.1f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        float speed = smoothSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, speed);
    }
}