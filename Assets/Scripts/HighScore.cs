using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI hiScoreText;

    // Start is called before the first frame update
    void Start()
    {
        SaveManager.Instance.LoadHiScore();
        hiScoreText.text = "High Score: " + SaveManager.Instance.playerName + " : " + SaveManager.Instance.hiScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
