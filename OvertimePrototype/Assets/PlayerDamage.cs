using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{

    public Collider myCollider;
    public Collider[] collisions;
    public void Start()
    {
        myCollider = gameObject.GetComponent<Collider>();
        collisions = new Collider[1];
    }
    public void Update()
    {

        collisions = Physics.OverlapBox(myCollider.bounds.center, myCollider.bounds.extents, myCollider.transform.rotation);

        if (collisions.Length > 0)
        {
            foreach (Collider collision in collisions)
            {
                if (collision.gameObject.tag == "Obstacle")
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision!");
        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
