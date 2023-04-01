using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : ButtonController
{
    private AudioSource menuAudio;

    public TMP_InputField nameIF;
    public TextMeshProUGUI playerBestScoreTxt;
    public AudioClip buttonAudio;

    private string playerName;
    private string playerBS;
    private int bestScore;

    private void Start()
    {
        menuAudio = GetComponent<AudioSource>();

        MainManager.Instance.LoadName();

        playerBS = MainManager.Instance.PlayerNameBS;
        bestScore = MainManager.Instance.BestScore;
        playerBestScoreTxt.text = playerBS + " - " + bestScore;
    }

    public void QuitGame()
    {
        menuAudio.PlayOneShot(buttonAudio, 1);
        Application.Quit();
    }

    public override void SetDisable(GameObject gameOb)
    {
        menuAudio.PlayOneShot(buttonAudio, 1);
        gameOb.SetActive(false);
    }

    public override void SetEnable(GameObject gameOb)
    {
        menuAudio.PlayOneShot(buttonAudio, 1);
        gameOb.SetActive(true);
    }

    public override void LoadSceneOption(int sceneNum)
    {
        menuAudio.PlayOneShot(buttonAudio, 1);
        SceneManager.LoadScene(sceneNum);
        playerName = nameIF.text;
        MainManager.Instance.PlayerName = playerName;
        MainManager.Instance.SaveName();
        Debug.Log(playerName);
    }
}
