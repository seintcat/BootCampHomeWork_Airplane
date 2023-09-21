using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUp : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject fx;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall") 
        {
            return;
        }
        Destroy(gameObject);
        Instantiate(fx).transform.position = transform.position;
        SoundManager.instance.fxAudio.PlayOneShot(clip);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
//public AudioClip clip;
//SoundManager.instance.fxAudio.PlayOneShot(clip);
