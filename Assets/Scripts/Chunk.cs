using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    float spawnAppleChance = .3f;

    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f};
    List<int> availableLanes= new List<int> { 0, 1, 2 };

    void Start()
    {
        SpawnFences();
        SpawnApple();
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

    int SlectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int slectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return slectedLane;
    }
}
