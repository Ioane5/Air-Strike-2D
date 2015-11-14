using UnityEngine;
using System.Collections;

public class DestoryByContact : MonoBehaviour
{


    public GameObject asteriodExplosion;
    public GameObject playerExplosion;

    private GameController gameController;
    public int destroyScore;
    // Use this for initialization
    void Start()
    {
        GameObject game = GameObject.FindWithTag("GameController");
        if(game != null)
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
        if(other.tag == "Player")
        {
            // instanciate player explosion only if player were hit by asteroid.
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        Instantiate(asteriodExplosion, transform.position, transform.rotation);
        gameController.addScore(destroyScore);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
