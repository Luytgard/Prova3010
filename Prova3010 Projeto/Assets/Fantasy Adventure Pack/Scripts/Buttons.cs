using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour // Nomes das cenas, entre aspas, devem ser os mesmos nomes das cenas na pasta Scenes
{
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu"); // Menu, or Title
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void GameButton()
    {
        SceneManager.LoadScene("GamePlay"); // GamePlay, or Main
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene("Tutorial"); // Tutorial
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}