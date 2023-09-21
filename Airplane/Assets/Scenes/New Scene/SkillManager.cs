using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public GameObject item;
    public float minTime = 3;
    public float maxTime = 5;

    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        StartCoroutine(Function());
    }

    // Update is called once per frame
    void Update()
    {
        //currentTime = currentTime + Time.deltaTime;
    }

    private IEnumerator Function()
    {
        while (true)
        {
            WaitForSeconds wait = new WaitForSeconds(Random.Range(minTime, maxTime));
            yield return wait;
            Instantiate(item).transform.position = transform.position;
        }
    }
}
