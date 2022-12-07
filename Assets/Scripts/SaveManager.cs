using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public string currentPlayerName;
    public string playerName;
    public int hiScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHiScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string currentPlayerName;
        public string playerName;
        public int hiScore;
    }

    public void SaveHiScore()
    {
        SaveData data = new SaveData();
        data.currentPlayerName = currentPlayerName;
        data.playerName = playerName;
        data.hiScore = hiScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHiScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            hiScore = data.hiScore;
            currentPlayerName = data.currentPlayerName;
        }
    }

    //public void SaveLastPlayer()
    //{
    //    SaveData data = new SaveData();
    //    data.currentPlayerName = currentPlayerName;

    //    string json = JsonUtility.ToJson(data);

    //    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    //}

    //public void LoadLastPlayer()
    //{
    //    string path = Application.persistentDataPath + "/savefile.json";
    //    if (File.Exists(path))
    //    {
    //        string json = File.ReadAllText(path);
    //        SaveData data = JsonUtility.FromJson<SaveData>(json);

    //        currentPlayerName = data.currentPlayerName;
    //    }
    //}
}
