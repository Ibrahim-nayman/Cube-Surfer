using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingsScreen;
    [SerializeField] private GameObject _audio;

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void NextGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Settings()
    {
        _settingsScreen.SetActive(true);
    }

    public void SoundOnOff()
    {
        _audio.SetActive(false);
    }
}