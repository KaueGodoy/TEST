using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public TextMeshProUGUI playButton;
    public TextMeshProUGUI quitButton;

    public void Play()
    {
        Debug.Log("Game starting...");
        StartGame();
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }

    private void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
