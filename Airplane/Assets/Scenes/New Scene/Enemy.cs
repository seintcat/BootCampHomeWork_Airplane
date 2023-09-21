using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    public int hp = 1;
    public GameObject fx;

    private Vector3 dir = Vector3.down;
    private bool follow;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMove p = FindObjectOfType<PlayerMove>();
        if(p == null)
        {
            Destroy(gameObject);
            Instantiate(fx).transform.position = transform.position;
            return;
        }
        player = p.transform;

        int check = Random.Range(0, 10);
        if (check < 1)
        {
            follow = true;
            return;
        }
        
        follow = false;
        if(check < 3)
        {
            dir = player.position - transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            if(player == null)
            {
                Destroy(gameObject);
                Instantiate(fx).transform.position = transform.position;
                return;
            }
            dir = player.position - transform.position;
        }
        transform.position += (dir.normalized * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (
            other.gameObject.tag == "Bullet" && 
            other.gameObject.GetComponent<Bullet>().tagNow == "Enemy"
           )
        {
            GameManager.attackScore += 10;
            hp--;
            if (hp <= 0)
            {
                GameManager.destroyScore += 100;
                Destroy(gameObject);
            }
        }
    }
}
