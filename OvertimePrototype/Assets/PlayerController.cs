using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform pointOne;
    public Transform pointTwo;
    public GameObject player;

    public float slideTime;
    public float slideAdjust;
    bool sliding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Right"))
        {
            player.transform.position = new Vector3(pointOne.position.x, player.transform.position.y, pointOne.position.z);
        }
        if (Input.GetButtonDown("Left"))
        {
            player.transform.position = player.transform.position = new Vector3(pointTwo.position.x, player.transform.position.y, pointTwo.position.z);
        }
        if (Input.GetButtonDown("Down") && !sliding) 
        {
            sliding = true;
            player.transform.position += Vector3.down * slideAdjust;
            StartCoroutine(SlideWait());
        }
    }

    IEnumerator SlideWait() 
    {
        yield return new WaitForSeconds(slideTime);
        player.transform.position -= Vector3.down * slideAdjust;
        sliding = false;
    
    }
}
