using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public Button restartButton;
    public int score = 0;
    public int lives;
    public float spawnRate = 1.0f;
    public bool isGameOver;
    public int pointBonus = 0;
    public GameObject pauseScreen;
    private bool paused;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CheckForPause();
        }
    }

    IEnumerator SpawnTarget()
    {

        while (!isGameOver)
        {

            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);


        }
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int addLive)
    {
        lives +=addLive;
        livesText.text = "Lives: " + lives;

        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {

        gameOverText.gameObject.SetActive(true);
        isGameOver = true;
        restartButton.gameObject.SetActive(true);

    }


    public void StartGame(float x, int y)
    {
        isGameOver = false;
        StartCoroutine(SpawnTarget());
        scoreText.text = "Score: " + score;
        lives = 3;
        livesText.text = "Lives: " + lives;
        spawnRate = x;
        pointBonus = y;
    }

    void CheckForPause()
    {
        if (!paused)

        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }

        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
