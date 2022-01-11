using UnityEngine;

public class DeathArea : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectableCube"))
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("MainBox"))
        {
            Destroy(other.gameObject);
        }
    }
}