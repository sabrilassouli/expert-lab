using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnPrefab;

    public float frequency;

    float lastSpawnedTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastSpawnedTime + frequency)
        {
            Spawn();
            lastSpawnedTime = Time.time;
        }
    }

    void Spawn()
    {
        GameObject newSpawnedGameobject = Instantiate(spawnPrefab, transform.position, Quaternion.identity);
        newSpawnedGameobject.transform.parent = transform;
    }
}
