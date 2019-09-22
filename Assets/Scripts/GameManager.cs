using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    public GameObject currentBall;
    public BallSpawner ballSpawner;
    public LevelManager levelManager;

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !ballSpawner.isSpawning
        && !UIManager.Instance.allLevelsCompletedPanel.activeSelf)
        {
            ballSpawner.StartSpawningSequence();
        }
    }

    public void CheckBalls()
    {
        GameObject[] allBalls = GameObject.FindGameObjectsWithTag("ball");
        if(allBalls.Length == 1)
        {
            StartCoroutine(levelManager.LoadNextLevel());
        }
    }

    public void GameOver()
    {
        UIManager.Instance.gameOverPanel.SetActive(true);
    }

    public void AllLevelsCompleted()
    {
        UIManager.Instance.allLevelsCompletedPanel.SetActive(true);
    }
}
