using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 10f;

    private Rigidbody2D body;

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 moveBy = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(moveBy * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
            body.AddForce(new Vector2(0, jumpForce));
    }
}