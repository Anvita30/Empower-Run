using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI HighScore;
    // Start is called before the first frame update
    void Start()
    {
        HighScore.text = "HIGH SCORE >> " + PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Rights");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
