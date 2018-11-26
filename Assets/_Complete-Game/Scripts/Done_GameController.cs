﻿//using UnityEngine;
//using UnityEngine.SceneManagement;
//using System.Collections;
//using UnityEngine.UI;

//public class Done_GameController : MonoBehaviour
//{
//    public GameObject[] hazards;
//    public Vector3 spawnValues;
//    public int hazardCount;
//    public float spawnWait;
//    public float startWait;
//    public float waveWait;

//    public Text scoreText;
//    public Text restartText;
//    public Text gameOverText;

//    private bool gameOver;
//    private bool restart;
//    private int score;

//    void Start()
//    {
//        gameOver = false;
//        restart = false;
//        restartText.text = "";
//        gameOverText.text = "";
//        score = 0;
//        UpdateScore();
//        StartCoroutine(SpawnWaves());
//    }

//    void Update()
//    {
//        if (restart)
//        {
//            if (Input.GetKeyDown(KeyCode.R))
//            {
//                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//            }
//        }
//    }

//    IEnumerator SpawnWaves()
//    {
//        yield return new WaitForSeconds(startWait);
//        while (true)
//        {
//            for (int i = 0; i < hazardCount; i++)
//            {
//                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
//                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
//                Quaternion spawnRotation = Quaternion.identity;
//                Instantiate(hazard, spawnPosition, spawnRotation);
//                yield return new WaitForSeconds(spawnWait);
//            }
//            yield return new WaitForSeconds(waveWait);

//            if (gameOver)
//            {
//                restartText.text = "Press 'R' for Restart";
//                restart = true;
//                break;
//            }
//        }
//    }

//    public void AddScore(int newScoreValue)
//    {
//        score += newScoreValue;
//        UpdateScore();
//    }

//    void UpdateScore()
//    {
//        scoreText.text = "Score: " + score;
//    }

//    public void GameOver()
//    {
//        gameOverText.text = "Perdu champion!";
//        gameOver = true;
//    }
//}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Done_GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text heartText;
    //  public Text restartText;
    public Text gameOverText;
    public GameObject restartButton;
    public GameObject returnButton;

    private bool gameOver;
    //  private bool restart;
    private int score;
    public int heart;

    void Start()
    {
        gameOver = false;
        gameOverText.text = "";
        restartButton.SetActive(false);
        returnButton.SetActive(false);
        score = 0;
        heart = 5;
        UpdateScore();
        UpdateHeart();
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartButton.SetActive(true);
                returnButton.SetActive(true);
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void RemoveHeart(int newHeartValue)
    {
        heart -= newHeartValue;
        UpdateHeart();
    }

    void UpdateHeart()
    {
        heartText.text = "Heart: " + heart;
    }

    public void GameOver()
    {
            gameOverText.text = "Vous avez perdu!";
            gameOver = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadOnClick(int level)
    {
        SceneManager.LoadScene(level);
    }

}