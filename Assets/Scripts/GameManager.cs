using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private Text levelText;
    static int reachedLevel = 0;

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private GameObject[] coins;
    [SerializeField]
    private GameObject coinPrefab;

    CoinGathering coinGathering;

    // Use this for initialization
    void Start()
    {
        coinGathering = GameObject.Find("Player").GetComponent<CoinGathering>();
        levelText.text = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetCoins()
    {
        // Reset all coins
        foreach (GameObject coin in coins)
        {
            coin.SetActive(true);
        }

        coinGathering.ResetPoints();
    }

    public void LoadLevel(string nextLevel)
    {
        Debug.Log(nextLevel);
        SceneManager.LoadScene(nextLevel);
    }
}
