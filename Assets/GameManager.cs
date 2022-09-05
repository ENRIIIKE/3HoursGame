using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Singleton
    //=====Singleton=====
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<GameManager>();
                }
            }
            return _instance;
        }
        private set { _instance = value; }
    }
    #endregion

    //Score
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject deathText;

    //Health
    public TextMeshProUGUI healthText;

    private void Start()
    {
        scoreText.text = "0";
        healthText.text = "100";
    }
    public void Score()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void Health(int health)
    {
        healthText.text = health.ToString();
    }
    public void EndGame()
    {
        deathText.SetActive(true);
    }
}
