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
            SceneManager.LoadScene("SampleScene");
        }
        else if (other.CompareTag("MainBox"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
