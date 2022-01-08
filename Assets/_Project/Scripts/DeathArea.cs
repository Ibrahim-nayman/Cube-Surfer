using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathArea : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectableCube"))
        {
            Destroy(other.gameObject, 0.05f);
        }
    }
}