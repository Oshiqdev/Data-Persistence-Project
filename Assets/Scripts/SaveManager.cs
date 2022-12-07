using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    // Holding the current player
    public string currentPlayerName;
    // Holding the player with the highest score
    public string playerName;
    // Holding the High Score
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

    // Saves the latest player, highest score and the player with the highest score
    public void SaveHiScore()
    {
        SaveData data = new SaveData();
        data.currentPlayerName = currentPlayerName;
        data.playerName = playerName;
        data.hiScore = hiScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    // Loads the latest player, highest score and the player with the highest score
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
}
