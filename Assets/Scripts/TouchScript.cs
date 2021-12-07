using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TouchScript : MonoBehaviour
{
    public GameObject startButton;
    public GameObject gameButtons;
    public GameObject pausePanel;
    public GameObject gameOverPanel;

    public Animator StartPanelAnim;
    public Animator GamePanelAnim;
    public Animator PausePanelAnim;

    public Text Count;
    public Text CountScoreEnd;
    public Text BestScore;
    
    public Text CoinsStart;
    public Text QuantityCoinsPerGame;
    public Text QuantityCoinsPerGameEnd;

    public void Save()
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + GameManager.instance.CoinScore);
        
        if(PlayerPrefs.GetInt("BestScore") < (int)GameManager.instance.GameScore)
            PlayerPrefs.SetInt("BestScore", (int)GameManager.instance.GameScore);
    }

    private void Start()
    {
        CoinsStart.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    private bool GameIsPlay()
    {
        return !GameManager.instance.GameIsOver && GameManager.instance.GameIsStarted &&
               !GameManager.instance.GameIsPaused;
    }
    

    private void Update()
    {
        Count.text = ((int)GameManager.instance.GameScore).ToString();
        
        if (GameIsPlay())
        {
            Count.text = ((int)GameManager.instance.GameScore).ToString();
            QuantityCoinsPerGame.text = GameManager.instance.CoinScore.ToString();
        }

        if (GameIsPlay())
        {
            if(Input.GetKeyDown("right"))
                Turn(true);
            if(Input.GetKeyDown("left"))
                Turn(false);
        }

        if (GameManager.instance.GameIsOver)
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        GameManager.instance.GameIsStarted = true;
        startButton.SetActive(false);
        StartPanelAnim.SetBool("GameStarted",true);
        gameButtons.SetActive(true);
        GamePanelAnim.SetBool("Resume",true);
        
    }

    public void StartPause()
    {
        gameButtons.SetActive(false);
        pausePanel.SetActive(true);
        GamePanelAnim.SetBool("Resume",false);
        PausePanelAnim.SetBool("GoToPause",true);
        GameManager.instance.GameIsPaused = true;

    }
    
    public void EndPause()
    {
        GameManager.instance.GameIsPaused = false;
        pausePanel.SetActive(false);
        gameButtons.SetActive(true);
        PausePanelAnim.SetBool("GoToPause",false);
        GamePanelAnim.SetBool("Resume",true);
    }

    public void Turn(bool isRightTurn)
    {
        if (isRightTurn)
        {
            GameManager.instance.TurnRight = true;
        }
        else
        {
            GameManager.instance.TurnLeft = true;    
        }
        
    }

    public void GameOver()
    {
        Save();
        gameOverPanel.SetActive(true);
        BestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
        CountScoreEnd.text = ((int)GameManager.instance.GameScore).ToString();
        QuantityCoinsPerGameEnd.text = GameManager.instance.CoinScore.ToString();
        
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
