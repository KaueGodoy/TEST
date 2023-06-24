using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool IsPaused;

    private float timePaused = 0f;
    private float timeRunning = 1f;

    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        IsPaused = false;
        pauseMenu.SetActive(false);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        if (playerControls.UI.Pause.triggered)
        {
            IsPaused = !IsPaused;

            if (IsPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }

        }

    }

    private void Pause()
    {
        Time.timeScale = timePaused;
        pauseMenu.SetActive(true);
    }

    private void Unpause()
    {
        IsPaused = false;
        Time.timeScale = timeRunning;
        pauseMenu.SetActive(false);
    }

    public void Resume()
    {
        Debug.Log("Resuming...");
        Unpause();
    }

    public void Restart()
    {
        Debug.Log("Restarting...");
        Unpause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Going to menu...");
        Unpause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit()
    {
        Debug.Log("Quitting the game...");
        Unpause();
        Application.Quit();
    }
}
