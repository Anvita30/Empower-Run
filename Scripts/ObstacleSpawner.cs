using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle1, obstacle2;
    public GameObject coinPrefab;
    [HideInInspector]
    public float obstacleSpawnInterval = 2.5f;
    [HideInInspector]
    public float coinSpawnInterval = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstacles");
        StartCoroutine("SpawnCoins");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isGameOver)
        {
            StopCoroutine("SpawnObstacles");
            StopCoroutine("SpawnCoins");
        }
    }

    private void SpawnObstacle()
    {
        int random = Random.Range(1,3);

        if(random == 1)
        {
            Instantiate(obstacle1, new Vector3(transform.position.x, -0.5f, 0), Quaternion.identity);
        }

        else if(random == 2)
        {
            Instantiate(obstacle2, new Vector3(transform.position.x, -0.5f, 0), Quaternion.identity);
        }

    }

    private void SpawnCoin()
    {
        int random = Random.Range(1,1);
        if(random == 1)
        {
            Instantiate(coinPrefab, new Vector3(transform.position.x, -0.5f, 0), Quaternion.identity);
        }
    }

    IEnumerator SpawnObstacles()
    {
        while(true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(obstacleSpawnInterval);
        }
    }

    IEnumerator SpawnCoins()
    {
        while(true)
        {
            SpawnCoin();
            yield return new WaitForSeconds(coinSpawnInterval);
        }
    }
}
