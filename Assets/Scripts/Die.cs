using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Die : MonoBehaviour
{

    [SerializeField]
    private Text livesText;
    private Vector3 startPosition;

    private GameManager gm;
    public int lives;
    EndGame endGame;

    [SerializeField]
    private float boundsX, boundsY;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        livesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x > boundsX || gameObject.transform.position.x < -boundsX || gameObject.transform.position.y > boundsY || gameObject.transform.position.y < -boundsY){
            transform.position = startPosition;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gm.ResetCoins();
            lives--;
            livesText.text = "Lives: " + lives;
        }

        if (lives <= 0) {
            endGame = FindObjectOfType<EndGame>();
            endGame.EndGameOnLevel((SceneManager.GetActiveScene().buildIndex + 1));
        }

    }
}
