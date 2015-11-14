using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public GameObject[] hazards;
    public GameObject[] powerUps;

    public int powerUpAfter;

    public float startWait;
    public float waveWait;
    public float hazardsInWave;
    public float spawnWait;
    private int score;
    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;
    public GUIText playerHealthText;
    private bool gameOver, restart;

    // Use this for initialization
    void Start()
    {
        gameOver = false;
        restart = false;
        UpdateScore();
        StartCoroutine(SpawnHazards());
    }


    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnHazards()
    {
        yield return new WaitForSeconds(2);
        int waveCount = 0;
        while (true)
        {
            waveCount++;
            for (int i = 0; i < hazardsInWave; i++)
            {
                GameObject flyingObject;

                // determine if we should throw hazard or power up.
                if (Random.Range(0, powerUpAfter + 1) == powerUpAfter)
                {
                    flyingObject = powerUps[Random.Range(0, powerUps.Length)];
                }
                else
                {
                    flyingObject = hazards[Random.Range(0, hazards.Length)];
                }
                float left = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
                float right = Camera.main.ViewportToWorldPoint(Vector3.one).x;
                float top = Camera.main.ViewportToWorldPoint(Vector3.one).z;
                GameObject instance = Instantiate(flyingObject, new Vector3(Random.Range(left, right), 0f, top + 5), Quaternion.identity) as GameObject;
                instance.GetComponent<Mover>().randomRange += 2 + waveCount;

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restart = true;
                restartText.enabled = true;
                break;
            }
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    }

    public void addScore(int newScore)
    {
        this.score += newScore;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.enabled = true;
    }

    public void UpdatePlayerHealth(int newHealth, int maxHealth)
    {
        double pertentage = (double)newHealth / maxHealth;
        pertentage *= 100;
        playerHealthText.text = "Health : " + (int)pertentage + "%";
    }
}
