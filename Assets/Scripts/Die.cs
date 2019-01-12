using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    private Vector3 startPosition;

    private GameManager playerSpawner;
    [SerializeField]
    private float boundsX, boundsY;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        playerSpawner = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x > boundsX || gameObject.transform.position.x < -boundsX || gameObject.transform.position.y > boundsY || gameObject.transform.position.y < -boundsY){
            playerSpawner.SpawnPlayer(startPosition);
            Destroy(this.gameObject);
        }
    }
}
