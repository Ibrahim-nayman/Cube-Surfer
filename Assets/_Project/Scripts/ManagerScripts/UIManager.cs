using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingsScreen;
    [SerializeField] private GameObject _audio;

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
        ScoreCounter.scoreValue = 0;
    }

    public void NextGame()
    {
        SceneManager.LoadScene("SampleScene");
        ScoreCounter.scoreValue = 0;
    }

    public void Settings()
    {
        _settingsScreen.SetActive(true);
    }

    public void SoundOff()
    {
        _audio.SetActive(false);
    }

    public void SoundOn()
    {
        _audio.SetActive(true);
    }

    public void Starting()
    {
        GameManager.Instance.CurrentGameState = GameManager.GameState.MainGame;
    }
}