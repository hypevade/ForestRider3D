using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public bool GameIsOver;
    public bool GameIsStarted;
    public bool GameIsPaused;
    public float GameScore;
    public int CoinScore;
    public int BusterScore;
    public bool TurnRight;
    public bool TurnLeft;
}
