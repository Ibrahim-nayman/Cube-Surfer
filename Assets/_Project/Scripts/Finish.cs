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
            //Destroy(other.gameObject,0.5f);
            GameManager.Instance.CurrentGameState = GameManager.GameState.WinGame;
        }

        if (other.CompareTag("MainBox"))
        {
            //Destroy(other.gameObject,1);
            GameManager.Instance.CurrentGameState = GameManager.GameState.WinGame;
        }
    }
}