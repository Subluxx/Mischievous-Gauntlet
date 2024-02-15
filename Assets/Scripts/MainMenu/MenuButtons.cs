using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void PlayGame() // MainMenu PlayGame
    {
        SceneManager.LoadScene("MiniGame 1");
    }

    public void QuitGame() // Quits Application
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
    public void OpenHowToPlay() // implement Gameplay Control UI
    {

    }
    public void CloseHowToPlay()
    {

    }
}
