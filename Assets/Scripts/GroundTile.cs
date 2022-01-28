using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [SerializeField] GameObject spikesPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject tallObstaclePrefab;

    float tallObstacleChance = 0.2f;
    private GameObject player;
    Collider m_Collider;
    Vector3 m_Size;

    TileManager groundSpawner;

    void Start()
    {
        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<Collider>();

        //Fetch the size of the Collider volume
        m_Size = m_Collider.bounds.size;

        groundSpawner = GameObject.FindObjectOfType<TileManager>();
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    private void Update()
    {
        //Failsafe if tile doesn't destroy itself
        if(player.transform.position.z - 30f > transform.position.z)
        {
            Destroy(gameObject);
        }

        //Output to the console the size of the Collider volume
        //Debug.Log("Collider Size : " + m_Size);
    }
    public void SpawnCoins()
    {
        float xPos = Random.Range(-4.5f, 4.5f);
        float zPos = Random.Range(-9.0f, 9.0f);

        Instantiate(coinPrefab, new Vector3(xPos, 0.1f, zPos), Quaternion.identity);
    }

    public void SpawnSpikes()
    {
        GameObject obstacleToSpawn = spikesPrefab;
        float random = Random.Range(0f, 1f);
        if(random < tallObstacleChance)
        {
            obstacleToSpawn = tallObstaclePrefab;
        } else
        {
            obstacleToSpawn = spikesPrefab;
        }
        int spikeSpawnXIndex = Random.Range(2, 5); //includes 2 but not 5
        int spikeSpawnZIndex = Random.Range(0, 2);
        Transform spawnPoint = transform.GetChild(spikeSpawnXIndex).transform.GetChild(spikeSpawnZIndex).transform;

        if(obstacleToSpawn == tallObstaclePrefab)
        {
            Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.Euler(0f, 0f, 0f), transform);
        } else
        {
            Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.Euler(0f, 90f, 0f), transform);
        }
    }

    public void SpawnEnemy()                                
    {
        int enemySpawnIndex = 5;
        int enemyZSpawnIndex = Random.Range(0, 2);
        int enemyXSpawnIndex = Random.Range(0, 3);
        Transform spawnPoint = transform.GetChild(enemySpawnIndex).transform.GetChild(enemyZSpawnIndex).transform.GetChild(enemyXSpawnIndex).transform;                   

        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnRightCoins()
    {
        int coinSpawnIndex = Random.Range(0, 4);
        Transform spawnPoint = transform.GetChild(6).transform.GetChild(coinSpawnIndex).transform;

        Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnMiddleCoins()
    {
        int coinSpawnIndex = Random.Range(0, 4);
        Transform spawnPoint = transform.GetChild(7).transform.GetChild(coinSpawnIndex).transform;

        Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnLeftCoins()
    {
        int coinSpawnIndex = Random.Range(0, 4);
        Transform spawnPoint = transform.GetChild(8).transform.GetChild(coinSpawnIndex).transform;

        Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity, transform);
    }
    //public void SpawnCoins()
    //{
        //int coinsToSpawn = 5;
        
        /*for(int i=0; i<coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }*/
    //}

   /* Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3
        (
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        if(point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }*/
}
