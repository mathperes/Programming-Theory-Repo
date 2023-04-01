using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : ButtonController
{
    private AudioSource gameAudio;

    [Header("Texts Settings")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI bestScoreText;

    [Header("Pause Settings")]
    public GameObject pausePanel;

    [Header("Audio Settings")]
    public AudioClip explosionAudio;
    public AudioClip buttonAudio;

    private int score;
    private int health;

    private string playerName;
    private string playerNameBS;
    private int playerBS;

    private bool audioPlay = false;

    public bool AudioPlay { get { return audioPlay; } set { audioPlay = value; } }

    public int Health
    {
        get { return health; }
    }

    // Start is called before the first frame update
    void Start()
    {        
        gameAudio = GetComponent<AudioSource>();

        health = 3;
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;

        playerName = MainManager.Instance.PlayerNameBS;
        playerBS = MainManager.Instance.BestScore;
        bestScoreText.text = playerName + " - " + playerBS;
    }
    private void Update()
    {
        PlayAudio();
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

    public override void SetDisable(GameObject gameOb)
    {
        gameAudio.PlayOneShot(buttonAudio, 1);
        if (gameOb.name == "Pause Panel")
        {
            Time.timeScale = 1;
        }
        gameOb.SetActive(false);
    }

    public override void SetEnable(GameObject gameOb)
    {
        gameAudio.PlayOneShot(buttonAudio, 1);
        if (gameOb.name == "Pause Panel")
        {
            Time.timeScale = 0;
        }        
        gameOb.SetActive(true);
    }

    public override void LoadSceneOption(int sceneNum)
    {
        gameAudio.PlayOneShot(buttonAudio, 1);
        SceneManager.LoadScene(sceneNum);
        Time.timeScale = 1;
    }

    private void SetBestScore(int point, int bestPoint)
    {
        score = point;

        if (point > bestPoint)
        {
            MainManager.Instance.BestScore = point;
            MainManager.Instance.PlayerNameBS = MainManager.Instance.PlayerName;
            MainManager.Instance.SaveName();
        }
    }

    public void GameOver()
    {
        SetBestScore(score, playerBS);
    }

    public void PlayAudio()
    {
        if (audioPlay)
        {
            gameAudio.PlayOneShot(explosionAudio, 1);
            audioPlay = false;
        }        
    }
}
