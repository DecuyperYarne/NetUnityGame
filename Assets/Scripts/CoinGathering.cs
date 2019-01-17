using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGathering : MonoBehaviour
{

    [SerializeField]
    private int coinAmount;
    private int maxCoins = 3;
    public string nextLevel;

    GameManager gameManager;

    private bool levelBeat = false;
    [SerializeField]
    private float timeTillNextLevel;

    void Start()
    {
        coinAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (levelBeat)
        {
            timeTillNextLevel -= Time.deltaTime;
            if (timeTillNextLevel < 0)
                Debug.Log(nextLevel);
                gameManager.LoadLevel(nextLevel);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Coin")
        {
            coll.gameObject.SetActive(false);
            coinAmount += 1;
            if (coinAmount == maxCoins)
            {
                levelBeat = true;
                Debug.Log("Victory!");
            }
        }
    }

    public void ResetPoints()
    {
        coinAmount = 0;
    }
}
