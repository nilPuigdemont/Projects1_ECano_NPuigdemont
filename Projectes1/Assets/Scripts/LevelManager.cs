using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textUI;
    public static bool palyerDead;
    void Awake()
    {
        palyerDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene(0);
        }

        if(palyerDead == true)
        {
            textUI.SetActive(true);
        }else
        {
            textUI.SetActive(false);
        }
       
    }
}
