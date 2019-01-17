using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;


public class EndGame : MonoBehaviour
{
    [SerializeField]
    private Text highscoreText;
    [SerializeField]
    private InputField nicknameInput;
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
        StartCoroutine(SendHighscore());

        reachedLevel = 0;
        SceneManager.LoadScene(0);
    }

    public void ShowHighscores() {
        StartCoroutine(SendHighscore());
        Application.OpenURL("https://localhost:44371/highscores");
    }


    IEnumerator SendHighscore() {
        WWWForm form = new WWWForm();
        form.AddField("name", nicknameInput.text);
        form.AddField("highscore", reachedLevel);

        using (UnityWebRequest www = UnityWebRequest.Post("https://localhost:44371/end", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
