using UnityEngine;
using System.Collections;

public class DestoryByContact : MonoBehaviour
{

    public GameObject asteriodExplosion;
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
            Destroy(other.gameObject);
        }
        Instantiate(asteriodExplosion, transform.position, transform.rotation);
        gameController.addScore(destroyScore);
        Destroy(gameObject);
    }
}
