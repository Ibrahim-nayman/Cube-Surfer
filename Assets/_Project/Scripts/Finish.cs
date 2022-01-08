using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectableCube"))
        {
            //SceneManager.LoadScene("SampleScene");
            GameManager.Instance.CurrentGameState = GameManager.GameState.StartGame;
        }
        else if (other.CompareTag("Player"))
        {
            //SceneManager.LoadScene("SampleScene");
            GameManager.Instance.CurrentGameState = GameManager.GameState.StartGame;
        }
    }
}