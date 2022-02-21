using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableObstacle : MonoBehaviour
{
    public GameObject attackZone;
    public Rigidbody body;
    public float bodyOffset;
    public float maxRandomPosition;
    public float minRandomPosition;
    public float forceMin;
    public float forceMax;
    public void Start()
    {
        
    }

    private void Update()
    {

    }
    public void Launch()
    {
        //transform.parent = transform.parent.parent.parent;
        body.useGravity = true;

        attackZone.active = false;

        Vector3 randomPosition = body.transform.right * Random.Range(minRandomPosition, maxRandomPosition);
        randomPosition += body.transform.up * Random.Range(minRandomPosition, maxRandomPosition);

        float explosionStrength = Random.Range(forceMin, forceMax);
        body.AddExplosionForce(explosionStrength, body.transform.position + (body.transform.forward * bodyOffset) + randomPosition, (2 * (maxRandomPosition * maxRandomPosition)) + (bodyOffset * bodyOffset));

        foreach (Transform transform in body.transform)
        {

            transform.gameObject.tag = "Untagged";

        }
    
    }
}
