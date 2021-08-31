using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveBy = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(moveBy * Time.deltaTime * speed);
    }
}
