using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public InputField inputField;
    public TextMeshProUGUI hiScoreText;

    public string nameInput;

    // Start is called before the first frame update
    void Start()
    {
        // Loads the last player name, the current High Score and the player with the highest score
        SaveManager.Instance.LoadHiScore();
        // Displays the High Score info
        hiScoreText.text = "High Score: " + SaveManager.Instance.playerName + " : " + SaveManager.Instance.hiScore;
        // Displays the last player name in the name field
        inputField.text = SaveManager.Instance.currentPlayerName;
    }

    // When a new name is enetered in the name field, update the last player name
    public void NewNameInput(string name)
    {
        nameInput = name;

        SaveManager.Instance.currentPlayerName = name;
        SaveManager.Instance.SaveHiScore();
    }

    // Loads the game scene
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    // Exits the game
    public void Exit()
    {

    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif

    }
}
