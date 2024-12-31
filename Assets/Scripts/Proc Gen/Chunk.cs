using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinsPrefab;

    float spawnAppleChance = .3f;
    float spawnCoinsChance = .5f;
    [SerializeField] float coinSeperationLength = 2f;


    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f};
    List<int> availableLanes= new List<int> { 0, 1, 2 };

    void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoins();
    }
    void SpawnFences()
    {
        int fencesToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0) break;

            int slectedLane = SlectLane();

            Vector3 spawnPosition = new Vector3(lanes[slectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    void SpawnApple()
    {
        if (Random.value > spawnAppleChance || availableLanes.Count <= 0) return;

        int slectedLane = SlectLane();

        Vector3 spawnPosition = new Vector3(lanes[slectedLane], transform.position.y, transform.position.z);
        Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform);
    }

    void SpawnCoins()
    {
        if (Random.value > spawnCoinsChance || availableLanes.Count <= 0) return;

        int slectedLane = SlectLane();
        
        int maxCoinsToSpawn = 6;
        int coinsToSpawn = Random.Range(1, maxCoinsToSpawn);

        float topOfChunkZPos = transform.position.z + (coinSeperationLength * 2f);

        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnPositionZ = topOfChunkZPos - (i * coinSeperationLength);   
            Vector3 spawnPosition = new Vector3(lanes[slectedLane], transform.position.y, spawnPositionZ);
            Instantiate(coinsPrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    int SlectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int slectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return slectedLane;
    }
}
