using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public GameObject hazard;

    // Use this for initialization
    void Start()
    {
        SpawnHazards();
    }

    void SpawnHazards()
    {

        float left = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        float right = Camera.main.ViewportToWorldPoint(Vector3.one).x;
        float top = Camera.main.ViewportToWorldPoint(Vector3.one).z;
        Instantiate(hazard, new Vector3(Random.Range(left, right), 0f, top + 5), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
