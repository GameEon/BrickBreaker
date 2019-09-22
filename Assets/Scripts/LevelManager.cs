using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = -1;
    public GameObject[] allLevels;

    void Start()
    {
        NextLevel();
    }

    public void NextLevel()
    {
        for(int i=0;i<allLevels.Length;i++)
        {
            allLevels[i].SetActive(false);
        }
        currentLevel ++;
        if(currentLevel < allLevels.Length+1)
        {
            allLevels[currentLevel-1].SetActive(true);
            UIManager.Instance.levelNumber.text = "Level: "+currentLevel.ToString();
            GameManager.Instance.ballSpawner.numberOfBallsToSpawn = allLevels[currentLevel-1].GetComponent<LevelData>().numberOfBalls;
            UIManager.Instance.numberOfBalls.text = "Number Of Balls: " + GameManager.Instance.ballSpawner.numberOfBallsToSpawn.ToString();
        }
        else
        {
            GameManager.Instance.AllLevelsCompleted();
        }
    }

    public IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(1);
        if(CanPlayerProceedToNextLevel())
        {
            GameManager.Instance.ballSpawner.CreateNewBallToShoot();
            GameManager.Instance.ballSpawner.ResetSpawner();
            NextLevel();
        }
        else
        {
            //These two lines will create new balls and reset the spawner so player can try again
            GameManager.Instance.ballSpawner.CreateNewBallToShoot();
            GameManager.Instance.ballSpawner.ResetSpawner();
            
            //This condition will show a heart breaking game over screen :(
            // GameManager.Instance.GameOver();
            /*TODO Tweak as per your requirement
            You can use either Game Over condition of give player more balls to continue playing
            */
        }
    }

    bool CanPlayerProceedToNextLevel()
    {
        GameObject[] allBoxes = GameObject.FindGameObjectsWithTag("box");
        if(allBoxes.Length == 0)
            return true;
        else
            return false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            NextLevel();
        }
    }
}
