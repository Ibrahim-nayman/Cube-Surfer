using UnityEngine;

public class Ground : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CurrentGameState = GameManager.GameState.LoseGame;
        }
    }
}