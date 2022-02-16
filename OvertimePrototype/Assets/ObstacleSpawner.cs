using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleSpawner : MonoBehaviour
{

    public List<GameObject> obstacles;
    public Transform obstacleSpawnPointOne;
    public Transform obstacleSpawnPointTwo;
    public float spawnChance;
    public bool spawnEmpty;

    // Start is called before the first frame update
    void Start()
    {
        

        if (!spawnEmpty)
        {
            int obstacleOne = Random.Range(1, obstacles.Count);
            int obstacleTwo = Random.Range(1, obstacles.Count);
            Debug.Log(obstacleOne);
            Instantiate(obstacles[obstacleOne], obstacleSpawnPointOne);
            Instantiate(obstacles[obstacleTwo], obstacleSpawnPointTwo);
        }
    }


}
