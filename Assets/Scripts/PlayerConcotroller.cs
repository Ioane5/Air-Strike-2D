using UnityEngine;
using System.Collections;

public class PlayerConcotroller : MonoBehaviour
{

    public GameObject explosion;
    public GameController gameController;
    public float speed;
    public float tiltSide;
    public float tiltFront;
    public int health;
    private int currHealth;


    public GameObject bolt;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire = 0f;

    void Start()
    {
        currHealth = health;
    }

    void Update()
    {
        if ((Input.GetButton("Fire1") || Input.GetKeyDown(KeyCode.Space)) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bolt, shotSpawn.position, Quaternion.identity);
        }

    }

    void FixedUpdate()
    {
        float inputHoriz = Input.GetAxis("Horizontal");
        float inputVert = Input.GetAxis("Vertical");

        Rigidbody rigid = GetComponent<Rigidbody>();

        rigid.velocity = new Vector3(inputHoriz, 0.0f, inputVert) * speed;
        rigid.rotation = Quaternion.Euler(new Vector3(rigid.velocity.z * tiltFront, 0.0f, rigid.velocity.x * -tiltSide));
    }

    void LateUpdate()
    {
        // camera borders
        float left = Camera.main.ViewportToWorldPoint(Vector3.zero).x * 0.9f;
        float right = Camera.main.ViewportToWorldPoint(Vector3.one).x * 0.9f;
        float bottom = Camera.main.ViewportToWorldPoint(Vector3.zero).z * 0.7f;
        float top = Camera.main.ViewportToWorldPoint(Vector3.one).z * 0.55f;

        Rigidbody rigid = GetComponent<Rigidbody>();

        rigid.position = new Vector3
           (
               Mathf.Clamp(rigid.position.x, left, right),
               Mathf.Clamp(rigid.position.y, -3f, 3f),
               Mathf.Clamp(rigid.position.z, bottom, top)
           );
    }

    public void UpdateHealth(int delta)
    {
        currHealth += delta;
        if (currHealth < 0)
            currHealth = 0;
        gameController.UpdatePlayerHealth(currHealth, health);
        if (currHealth == 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameController.GameOver();
            Destroy(gameObject);
        }
    }
}
