using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnRate = 2f; // Rate at which coins spawn
    public float spawnXPosition = 10f; // X position where coins spawn
    public float spawnYPositionMin = -1f; // Min Y position where coins spawn
    public float spawnYPositionMax = 3f; // Max Y position where coins spawn

    private float nextSpawnTime;

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnCoin();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    private void SpawnCoin()
    {
        float randomYPosition = Random.Range(spawnYPositionMin, spawnYPositionMax);
        Vector2 spawnPosition = new Vector2(spawnXPosition, randomYPosition);
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
