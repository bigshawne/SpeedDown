using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Randomly spawn pre-built platforms
*/
public class Spawner : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();

    public float spawnTime;
    private float countTime;
    private Vector3 spawnPosition;

    // Update is called once per frame
    void Update()
    {
        SpawnPlatform();
    }

    public void SpawnPlatform()
    {
        countTime += Time.deltaTime;
        spawnPosition = transform.position;

        // Spawn position x range is between -3.4 to 3.4
        spawnPosition.x = Random.Range(-3.4f, 3.4f);

        if (countTime >= spawnTime)
        {
            CreatePlatform();
            countTime = 0;
        }
    }

    public void CreatePlatform()
    {
        int index = Random.Range(0, platforms.Count);

        int spikeNum = 0;

        if (index == 4)
        {
            spikeNum++;
        }

        if (spikeNum > 1)
        {
            spikeNum = 0;
            countTime = spawnTime;
            return;
        }
        
        GameObject newPlatform = Instantiate(platforms[index], spawnPosition, Quaternion.identity);
        // Make all the spawned platform be the children of the startLine GameObject
        newPlatform.transform.SetParent(this.gameObject.transform);
    }
}
