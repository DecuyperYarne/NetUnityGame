using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{

    [SerializeField]
    private float timeBetweenSpawns;
    [SerializeField]
    private float startTimeBetweenSpawns;

    public GameObject echo;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenSpawns <= 0)
        {
            GameObject instance = Instantiate(echo, transform.position, Quaternion.identity);
			Destroy(instance, .5f);
            timeBetweenSpawns = startTimeBetweenSpawns;
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }
}
