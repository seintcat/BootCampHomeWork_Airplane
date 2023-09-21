using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;
    public AudioClip clip;
    [HideInInspector]
    public string tagNow;
    [HideInInspector]
    public Vector3 dir = Vector3.up;

    [SerializeField]
    GameObject fx;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (dir * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == tagNow)
        {
            Destroy(gameObject);
            //Destroy(other.gameObject);
            if(fx != null)
            {
                Instantiate(fx).transform.position = other.transform.position;
            }
            SoundManager.instance.fxAudio.PlayOneShot(clip);
        }
    }
}
