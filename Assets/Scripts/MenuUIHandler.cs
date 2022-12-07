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

    public string nameInput;

    public int hiScore;

    // Start is called before the first frame update
    void Start()
    {
        SaveManager.Instance.LoadHiScore();
        inputField.text = SaveManager.Instance.currentPlayerName;
    }

    public void NewNameInput(string name)
    {
        nameInput = name;

        SaveManager.Instance.currentPlayerName = name;
        SaveManager.Instance.SaveHiScore();
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif

    }
}
