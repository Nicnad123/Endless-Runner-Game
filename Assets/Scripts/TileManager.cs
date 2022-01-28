using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnpoint;

    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnpoint, Quaternion.identity);
        nextSpawnpoint = temp.transform.GetChild(1).transform.position;

        if(spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnSpikes();
            temp.GetComponent<GroundTile>().SpawnLeftCoins();
            temp.GetComponent<GroundTile>().SpawnMiddleCoins();
            temp.GetComponent<GroundTile>().SpawnRightCoins();
            temp.GetComponent<GroundTile>().SpawnEnemy();
        }
    }

    private void Start()
    {
        for(int i = 0; i<15; i++)
        {
            if(i < 2)
            {
                SpawnTile(false);
            } else
            {
                SpawnTile(true);
            }
        }
    }
}
