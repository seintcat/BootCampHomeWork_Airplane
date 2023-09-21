using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject missile;
    public GameObject shootRoot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Transform _transform in shootRoot.GetComponentsInChildren<Transform>())
            {
                if(shootRoot.transform == _transform)
                {
                    continue;
                }

                GameObject _missile = Instantiate(missile);
                _missile.transform.rotation = Quaternion.Euler(_transform.rotation.eulerAngles);
                _missile.transform.position = _transform.position;
            }
        }
    }
}
