using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuBehaviour : MonoBehaviour
{
    public static bool isPaused;
    private void OnEnable()
    {
        Time.timeScale = 0f;
        isPaused = true;

    }
    private void OnDisable()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
