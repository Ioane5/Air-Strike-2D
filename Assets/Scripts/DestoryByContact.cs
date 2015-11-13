using UnityEngine;
using System.Collections;

public class DestoryByContact : MonoBehaviour
{


    public GameObject asteriodExplosion;
    public GameObject playerExplosion;

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Undestroyable")
        {
            return;
        }
        if(other.tag == "Player")
        {
            // instanciate player explosion only if player were hit by asteroid.
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        Instantiate(asteriodExplosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
