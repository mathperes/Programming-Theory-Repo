using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public GameObject pausePanel;

    private int score;
    private int health;

    public int Health
    {
        get { return health; }
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateHealth(int healthToAdd)
    {
        health -= healthToAdd;
        healthText.text = "Health: " + health;
    }

    public void GamePause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumePause()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

}
