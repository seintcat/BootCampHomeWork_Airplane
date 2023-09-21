using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 40f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Time.deltaTime * moveSpeed * Vector3.up);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.back);
        }
    }
}
