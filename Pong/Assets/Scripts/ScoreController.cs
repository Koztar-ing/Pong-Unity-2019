using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    [SerializeField] Text playerScoreText, enemyScoreText, resultText;
    int playerScore, enemyScore;
    bool isAI;
    GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        if (gameController.startedFromP1) isAI = true;
        else isAI = false;

        playerScoreText.text = playerScore.ToString();
        enemyScoreText.text = enemyScore.ToString();

        if (playerScore == 5)
        {
            Time.timeScale = 0;
            playerScoreText.gameObject.SetActive(false);
            enemyScoreText.gameObject.SetActive(false);
            resultText.gameObject.SetActive(true);
            resultText.text = "Player1 WON!";
            StartCoroutine(Restart());
        }
        else if (enemyScore == 5)
        {
            Time.timeScale = 0;
            playerScoreText.gameObject.SetActive(false);
            enemyScoreText.gameObject.SetActive(false);
            resultText.gameObject.SetActive(true);
            if(isAI) resultText.text = "Enemy WON!";
            else resultText.text = "Player2 WON!";
            StartCoroutine(Restart());
        }
    }

    public void AddScoreToPlayer1()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
    }

    public void AddScoreToEnemy()
    {
        enemyScore++;
        enemyScoreText.text = enemyScore.ToString();
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}