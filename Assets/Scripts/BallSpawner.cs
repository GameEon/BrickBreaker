using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public bool isSpawning = false;
    public float waitTimeBetweenSpawns = 0.1f;
    public int ballSpeed = 100;
    public int numberOfBallsToSpawn = 10;
    Vector3 ballInitPosition;
    Vector2 direction;
    Vector2 tempDir;
    Vector3 worldMousePos;
    GameObject currentBall;
    // Start is called before the first frame update
    void Start()
    {
        ballInitPosition = ballPrefab.transform.position;
        GetCurrentBall();
    }

    void GetCurrentBall()
    {
        currentBall = transform.GetChild(0).gameObject;
    }

    public void GenerateNewBall(int ballsSpawned)
    {
        currentBall.GetComponent<Rigidbody2D>().AddForce(tempDir * ballSpeed);
        currentBall.transform.parent = null;
        if (ballsSpawned < numberOfBallsToSpawn)
        {
            CreateNewBallToShoot();
        }
    }

    public void StartSpawningSequence()
    {
        isSpawning = true;
        StartCoroutine(SpawnBalls());
    }

    IEnumerator SpawnBalls()
    {
        tempDir = direction;
        for (int i = 0; i < numberOfBallsToSpawn + 1; i++)
        {
            GenerateNewBall(i);
            UIManager.Instance.numberOfBalls.text = "Number Of Balls: " + (numberOfBallsToSpawn - i).ToString();
            yield return new WaitForSeconds(waitTimeBetweenSpawns);
        }
    }

    void Update()
    {
        worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize();
    }

    public void CreateNewBallToShoot()
    {
        GameObject newBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        newBall.transform.parent = transform;
        GetCurrentBall();
    }

    public void ResetSpawner()
    {
        isSpawning = false;
    }
}
