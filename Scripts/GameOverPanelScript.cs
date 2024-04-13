using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Rights");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadGame2()
    {
        SceneManager.LoadScene("Game2");
    }

    public void LoadGame3()
    {
        SceneManager.LoadScene("Game3");
    }

    public void LoadGame4()
    {
        SceneManager.LoadScene("Game4");
    }

    public void LoadGame5()
    {
        SceneManager.LoadScene("Game5");
    }
}
