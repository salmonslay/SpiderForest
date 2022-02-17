using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    public float speed = 1f;
    private int myDirection = 1;

    // Start is called before the first frame update
    void Start()
    {
        myDirection = PlayerMovement.direction;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveBy = new Vector3(myDirection, 0, 0);
        transform.Translate(moveBy * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KillCheck") || collision.CompareTag("Player")) return;

        if (collision.CompareTag("Enemy")){
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.Kill();
        }

        Destroy(gameObject);
    }
}
