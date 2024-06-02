using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuBehaviour : MonoBehaviour
{
    public static bool isPaused;
    public GameObject remainingEnemies;
    private void OnEnable()
    {
        Time.timeScale = 0f;
        isPaused = true;
        remainingEnemies.SetActive(false);

    }
    private void OnDisable()
    {
        Time.timeScale = 1f;
        isPaused = false;
        remainingEnemies.SetActive(true);
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
