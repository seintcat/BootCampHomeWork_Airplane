using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    public Transform gunPos;
    private int skillLevel;

    // Start is called before the first frame update
    void Start()
    {
        skillLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ExcuteSkill();
        }
    }

    public void ExcuteSkill()
    {
        Bullet _bullet;
        List<Vector3> posList = new List<Vector3>();
        posList.Add(new Vector3(0, 0, 0));
        posList.Add(new Vector3(-0.3f, 0, 0));
        posList.Add(new Vector3(0.3f, 0, 0));
        List<Quaternion> rotateList = new List<Quaternion>();
        rotateList.Add(Quaternion.Euler(0, 0, 0));
        rotateList.Add(Quaternion.Euler(0, 0, -30));
        rotateList.Add(Quaternion.Euler(0, 0, 30));

        switch (skillLevel)
        {
            case 0:
                _bullet = Instantiate(bullet).GetComponent<Bullet>();
                _bullet.transform.position = gunPos.position;
                _bullet.dir = Vector3.up;
                _bullet.tagNow = "Enemy";
                break;
            case 1:
                foreach (Vector3 nowPos in posList)
                {
                    _bullet = Instantiate(bullet).GetComponent<Bullet>();
                    _bullet.transform.position = gunPos.position + nowPos;
                    _bullet.dir = Vector3.up;
                    _bullet.tagNow = "Enemy";
                }
                break;
            case 2:
                for (int i = 0; i < 3; i++)
                {
                    _bullet = Instantiate(bullet).GetComponent<Bullet>();
                    _bullet.transform.position = gunPos.position + posList[i];
                    _bullet.transform.rotation = rotateList[i];
                    _bullet.dir = _bullet.transform.up;
                    _bullet.tagNow = "Enemy";
                }
                break;
            case 3:
                for (int i = 0; i < 24; i++)
                {
                    _bullet = Instantiate(bullet).GetComponent<Bullet>();
                    _bullet.transform.position = gunPos.position;
                    _bullet.transform.rotation = Quaternion.Euler(0, 0, 15 * i);
                    _bullet.dir = _bullet.transform.up;
                    _bullet.tagNow = "Enemy";
                }
                break;
            default:
                skillLevel = 3;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            skillLevel++;
        }
    }
}
