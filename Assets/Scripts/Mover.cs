using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed;
    public float randomRange;
	// Use this for initialization
	void Start () {
        float randSpeed = Random.Range(speed - randomRange,speed);
        GetComponent<Rigidbody>().velocity = transform.forward * randSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
