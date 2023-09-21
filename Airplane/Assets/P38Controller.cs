using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P38Controller : MonoBehaviour
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
        transform.Translate(Time.deltaTime * moveSpeed * Vector3.forward);

        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.left);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.forward);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.right);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.back);
        //}

        float pitch = Input.GetAxis("Vertical");
        float roll = Input.GetAxis("Horizontal");

        pitch = Mathf.Clamp(pitch, -1, 1);
        roll = Mathf.Clamp(roll, -1, 1);

        Vector3 rotation = new Vector3(pitch, 0, roll);

        transform.Rotate(Time.deltaTime * rotateSpeed * rotation);
    }
}
