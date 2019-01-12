using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private string nextLevel;

    [SerializeField]
    private Text levelText;

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

    public void SpawnPlayer(Vector3 position)
    {
        // Reset all coins
        foreach (GameObject coin in coins)
        {
            coin.SetActive(true);
        }

        // Reset player position
        Instantiate(playerPrefab, position, Quaternion.identity);
        coinGathering.ResetPoints();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
