using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;

    public GameObject hint_popup;
    public GameObject temp;

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
            case GameState.Death_1:
                HandleFirstDeath();
                break;
            case GameState.Death_2:
                HandleOtherDeaths();
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

    private void HandleFirstDeath()
    {

    }

    private void HandleOtherDeaths()
    {

    }

    private void HandleWin()
    {

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
    Death_1,
    Death_2,
    Win,
}