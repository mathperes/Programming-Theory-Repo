using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public string PlayerName;
    public string PlayerNameBS;
    public int BestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        LoadName();

        DontDestroyOnLoad(gameObject);
    }

    [Serializable]
    class SaveData
    {
        public string PlayerName;
        public string PlayerNameBS;
        public int BestScore;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.PlayerNameBS = PlayerNameBS;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            PlayerNameBS = data.PlayerNameBS;
            BestScore = data.BestScore;
        }
    }
}
