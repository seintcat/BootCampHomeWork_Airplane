using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P38Rig : MonoBehaviour
{
    public Transform target;
    public float movePower = 1;
    public float rotatePower = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * movePower);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * rotatePower);
    }
}
