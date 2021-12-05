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
    public Text CountShdow;
    public Text CountScoreEnd;

    

    
    

    public bool gameIsStarted;
    public bool gameIsPaused;
    public bool gameIsOver;


    public void Save(int coinsCount)
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + coinsCount);
    }
    
    private void Update()
    {
        Count.text = ((int)GameManager.instance.GameScore).ToString();
        CountShdow.text = Count.text;
        
        
        if (!GameManager.instance.GameIsOver && GameManager.instance.GameIsStarted && !GameManager.instance.GameIsPaused)
        {
            Count.text = ((int)GameManager.instance.GameScore).ToString();
            CountShdow.text = Count.text;


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
        gameOverPanel.SetActive(true);

    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
