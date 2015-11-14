using UnityEngine;
using System.Collections;

public class HealthRecover : MonoBehaviour
{

    public int health;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerConcotroller>().UpdateHealth(health);
            Destroy(gameObject);
        }
    }
}
