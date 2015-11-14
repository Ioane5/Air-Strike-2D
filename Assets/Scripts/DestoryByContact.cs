using UnityEngine;
using System.Collections;

public class DestoryByContact : MonoBehaviour
{

    public GameObject explosion;
    private GameController gameController;
    public int destroyScore;
    public int playerDamage;
    // Use this for initialization
    void Start()
    {
        GameObject game = GameObject.FindWithTag("GameController");
        if (game != null)
        {
            gameController = game.GetComponent<GameController>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Undestroyable")
        {
            return;
        }
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerConcotroller>().UpdateHealth(-playerDamage);
        }
        else
        {
            if (other.tag != "EnemyShip")
            {
                Destroy(other.gameObject);
            }
        }

        if (!(tag == "EnemyShip" && other.tag == "Asteroid"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameController.addScore(destroyScore);
            Destroy(gameObject);
        }
    }
}
