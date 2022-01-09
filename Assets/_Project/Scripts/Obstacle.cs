using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectableCube"))
        {
            Destroy(other.gameObject, 0.25f);
        }

        if (other.CompareTag("MainBox"))
        {
            Destroy(other.gameObject, 0.25f);
        }
    }
}