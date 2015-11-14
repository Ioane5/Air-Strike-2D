using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

    public float scrollSpeed;

    private float tileSize;
    private Vector3 startPosition;

    void Start()
    {
        tileSize = transform.localScale.y;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}
