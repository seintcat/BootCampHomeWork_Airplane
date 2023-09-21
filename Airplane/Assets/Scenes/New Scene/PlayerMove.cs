using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    public int hp = 10;
    [SerializeField]
    GameObject fx;
    [SerializeField]
    Image image;
    private Vector3 playerPos = new Vector3 (0, 0, 0);
    private Vector3 enemyPos = new Vector3 (5, 5, 0);
    private List<GameObject> gameObjects;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 direction = enemyPos - playerPos;
        float distance = direction.magnitude;
        gameObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = (Vector3.right * h) + (Vector3.up * v);
        //transform.Translate(dir * speed * Time.deltaTime);
        transform.position += (dir * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        int index = 0;

        while (index < gameObjects.Count)
        {
            if(gameObjects[index] == null)
            {
                gameObjects.RemoveAt(index);
                continue;
            }

            index++;
        }
        if (other.gameObject.tag == "Enemy")
        {
            hp = 0;
            image.fillAmount = 0;
        }
        else if(
            other.gameObject.tag == "Bullet" && 
            !gameObjects.Exists(x => x.name == other.gameObject.name) &&
            other.gameObject.GetComponent<Bullet>().tagNow == "Player"
            )
        {
            hp--;
            image.fillAmount = hp / 10.0f;
            gameObjects.Add(other.gameObject);
        }

        if(hp <= 0)
        {
            Instantiate(fx).transform.position = transform.position;
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Instantiate(fx).transform.position = transform.position;
        image.fillAmount = 0;
        Destroy(gameObject);
    }
}
