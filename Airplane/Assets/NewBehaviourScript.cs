using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(".");
        //Debug.LogWarning("?");
        //Debug.LogError("!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(0, 0, 1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(0, 0, -1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(1, 0, 0);
        }
    }
}
