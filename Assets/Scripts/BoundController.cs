using UnityEngine;
using System.Collections;

public class BoundController : MonoBehaviour
{


    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
