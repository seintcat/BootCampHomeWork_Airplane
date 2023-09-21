using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject fx;
    public float shootTime = 1f;

    [SerializeField]
    private float bulletSpeed = 1f;

    private IEnumerator fire;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>().transform;
        if(player == null)
        {
            return;
        }
        fire = Fire();
        StartCoroutine(fire);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Fire()
    {
        while(true)
        {
            if (player == null)
            {
                StopCoroutine(fire);
                Destroy(gameObject);
                Instantiate(fx).transform.position = transform.position;
                yield return null;
            }
            yield return new WaitForSeconds(shootTime);
            Bullet _bullet = Instantiate(bullet).GetComponent<Bullet>();
            _bullet.speed = bulletSpeed;
            _bullet.transform.position = transform.position;
            _bullet.dir = (player.position - gameObject.transform.position).normalized;
            _bullet.transform.rotation = Quaternion.LookRotation(_bullet.dir);
            _bullet.tagNow = "Player";
        }
    }
}
