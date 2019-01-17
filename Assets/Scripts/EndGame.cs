using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndGame : MonoBehaviour
{
    [SerializeField]
    private Text highscoreText;
    static int reachedLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (highscoreText && reachedLevel != 0) {
            highscoreText.text = "You reached level " + reachedLevel;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGameOnLevel(int level)
    {
        reachedLevel = level;
        SceneManager.LoadScene("endgame");
    }


    public void RestartGame() {
        reachedLevel = 0;
        SceneManager.LoadScene(0);
    }

    public void ShowHighscores() {
        Debug.Log("Highscores here");
    }
}
