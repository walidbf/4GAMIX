using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;

    public static int numberOfCoins;
    public Text coinsText;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    public static int score;
    public int highScore = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        numberOfCoins = 0;
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        score = 0;
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.text = "High Score : " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            PlayerPrefs.SetInt("highScore", highScore);
            PlayerPrefs.Save();
        }
        if (SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
            
        }
        if (isGameStarted && !gameOver)
        {
            score += 20;
        }
        coinsText.text = "Coins : " + PlayerManager.numberOfCoins;

        scoreText.text = "Score : " + score;
        if (score > highScore)
        {
            highScore = score;
        }
        highScoreText.text = "High Score : " + highScore;

    }
    private void FixedUpdate()
    {
        
    }
    public static void AddCoinsScore()
    {
        score += 500;
    }
}
