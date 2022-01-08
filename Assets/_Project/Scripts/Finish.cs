using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectableCube"))
        {
            GameManager.Instance.CurrentGameState = GameManager.GameState.WinGame;
        }
        else if (other.CompareTag("Player"))
        {
            GameManager.Instance.CurrentGameState = GameManager.GameState.WinGame;
        }
    }
}