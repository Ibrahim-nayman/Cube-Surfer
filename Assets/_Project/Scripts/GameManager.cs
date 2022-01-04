using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        StartGame,
        MainGame,
        LoseGame,
        WinGame
    }

    private static GameManager _instance;
    private GameState _currentGameState;
    
    public static GameManager Instance => _instance;
    public TextMeshProUGUI tapToStart;

    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        set
        {
            switch (value)
            {
                case GameState.StartGame:
                    break;
                case GameState.MainGame:
                    break;
                case GameState.LoseGame:
                    break;
                case GameState.WinGame:
                    break;
                default:
                    break;
            }

            _currentGameState = value;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        _currentGameState = GameState.StartGame;
    }

    private void Update()
    {
        switch (CurrentGameState)
        {
            case GameState.StartGame:
                break;
            case GameState.MainGame:
                break;
            case GameState.LoseGame:
                break;
            case GameState.WinGame:
                break;
            default:
                break;
        }
    }
}

    

