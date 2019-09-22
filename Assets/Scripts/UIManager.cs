using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<UIManager>();
            }

            return _instance;
        }
    }
    public Text numberOfBalls;
    public Text levelNumber;
    public GameObject gameOverPanel;
    public GameObject allLevelsCompletedPanel;

    public void RetryGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
