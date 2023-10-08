using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;

    public GameObject hint_popup;
    public GameObject temp;
    
    public float playerDeaths;
    public float playerWins;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public static event Action<GameState> OnGameStateChanged;

    void Start()
    {
      
    }

    void Update()
    {
        
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Start:
                HandleGameStart();
                break;
            case GameState.Playing:
                HandlePlaying();
                break;
            case GameState.Death:
                HandleDeaths();
                break;
            case GameState.Win:
                HandleWin();
                break;
            default:
                break;
        }

        OnGameStateChanged?.Invoke(newState);

    }

    private void HandleGameStart()
    {
        temp = GameObject.Instantiate(hint_popup);
    }

    private void HandleDeaths()
    {
        playerDeaths++;
        temp = Instantiate(hint_popup);
    }

    private void HandleWin()
    {
        Destroy(temp);

        playerWins++;

        if(playerWins == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (playerWins == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (playerWins == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void HandlePlaying()
    {
        Destroy(temp);
    }
}


public enum GameState
{
    Start,
    Playing,
    Death,
    Win,
}