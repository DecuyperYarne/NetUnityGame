using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    private Vector3 startPosition;

    private GameManager gm;
    [SerializeField]
    private float boundsX, boundsY;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x > boundsX || gameObject.transform.position.x < -boundsX || gameObject.transform.position.y > boundsY || gameObject.transform.position.y < -boundsY){
            transform.position = startPosition;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gm.ResetCoins();
        }
    }
}
