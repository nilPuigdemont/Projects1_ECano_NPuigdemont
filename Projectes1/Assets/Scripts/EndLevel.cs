using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private int nextScene;
    void Start()
    {
        LevelManager.Instance.endLevel = this.gameObject;
        this.gameObject.SetActive(false);

        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
      

        if ( nextScene >= SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
