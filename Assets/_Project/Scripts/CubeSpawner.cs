using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public Transform Upper;
    public Transform CubeSpawnerObject;
    public GameObject Cube;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectableCube"))
        {
            Destroy(other.gameObject);
            Vector3 pos = Upper.localPosition;
            pos.y += 1;
            Upper.localPosition = pos;
            var spawnedCube = Instantiate(Cube, CubeSpawnerObject.position, Quaternion.identity);
            spawnedCube.layer = 7;
            spawnedCube.transform.SetParent(Upper);
        }
    }
}