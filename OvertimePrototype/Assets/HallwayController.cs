using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayController : MonoBehaviour
{
    public List<GameObject> hallwayTypes;
    public List<GameObject> instantiatedHallways;
    public Transform hallwayContainer;
    public float speed;
    public int warmupCount;

    // Start is called before the first frame update
    void Start()
    {
        instantiatedHallways = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (instantiatedHallways.Count <= 30) 
        {
            SpawnHallway();
        }
        MoveHallways();
    }

    public void SpawnHallway() 
    {
        int hallwayPick = Random.Range(0, hallwayTypes.Count);
        GameObject instantiatedHallway = Instantiate(hallwayTypes[hallwayPick], hallwayContainer);

        if (instantiatedHallways.Count != 0)
        {
            instantiatedHallway.transform.position = (instantiatedHallways[instantiatedHallways.Count - 1].transform.position + (Vector3.forward * 10f));
        }
        else 
        {
            instantiatedHallway.transform.position = Vector3.zero;
        }

        if (warmupCount > 0) 
        {
            instantiatedHallway.GetComponent<ObstacleSpawner>().spawnEmpty = true;
            warmupCount--;
        }
        instantiatedHallways.Add(instantiatedHallway);



    }

    public void MoveHallways() 
    {
        for (int i = 0; i < instantiatedHallways.Count; i++) 
        {
            instantiatedHallways[i].transform.position += Vector3.back * Time.deltaTime * speed;
            if (instantiatedHallways[i].transform.position.z <= -25) 
            {
                GameObject condemnedHallway = instantiatedHallways[i];
                Destroy(condemnedHallway);
                instantiatedHallways.RemoveAt(i);
                i--;
            }
        }
    
    
    }
}
