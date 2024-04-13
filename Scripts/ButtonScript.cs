using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
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

    public void back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
