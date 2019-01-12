using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{

    [SerializeField]
    private float updown, boundsX, moveDirection; //1 left, -1 right

	[SerializeField]
	private float speed;

    // Use this for initialization
    void Start()
    {
        boundsX = 10f;
		GiveNewSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.left * speed * Time.deltaTime * moveDirection;

		// Move towards left boundary
        if (gameObject.transform.position.x < -boundsX && moveDirection == 1)
        {
            gameObject.transform.position = new Vector3(boundsX, transform.position.y, 0);
			GiveNewSpeed();
        }

		// Move towards right boundary
        if (gameObject.transform.position.x > boundsX && moveDirection == -1)
        {
            gameObject.transform.position = new Vector3(-boundsX, transform.position.y, 0);
			GiveNewSpeed();
        }
    }

    private void GiveNewSpeed()
    {
        speed = UnityEngine.Random.Range(.5f, 2f);
    }
}
