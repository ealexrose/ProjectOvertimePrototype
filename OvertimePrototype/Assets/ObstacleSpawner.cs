using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleSpawner : MonoBehaviour
{

    public List<ObstacleListItem> obstacles;
    public Transform obstacleSpawnPointOne;
    public Transform obstacleSpawnPointTwo;
    public float spawnChance;
    public bool spawnEmpty;

    // Start is called before the first frame update
    void Start()
    {
        

        if (!spawnEmpty)
        {
            int obstacleOne = Random.Range(0, obstacles.Count);
            int obstacleTwo = Random.Range(0, obstacles.Count);

            Debug.Log(obstacleOne);
            while (obstacles[obstacleOne].obstacleType == ObstacleListItem.ObstacleType.wall && obstacles[obstacleTwo].obstacleType == ObstacleListItem.ObstacleType.wall) 
            {
                obstacleTwo = Random.Range(1, obstacles.Count);
            }

            Instantiate(obstacles[obstacleOne].obstacle, obstacleSpawnPointOne);
            Instantiate(obstacles[obstacleTwo].obstacle, obstacleSpawnPointTwo);

        }
    }


}

[System.Serializable]
public class ObstacleListItem
{
    public GameObject obstacle;
    public ObstacleType obstacleType;
    public enum ObstacleType 
    {
        slide,
        jump,
        attack,
        wall,
        empty
    }

}
