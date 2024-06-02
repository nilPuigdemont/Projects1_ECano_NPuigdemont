using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;

    [HideInInspector] public bool palyerDead;
    [HideInInspector] public GameObject enemyList;
    [HideInInspector] public GameObject endLevel;

    private int totalEnemies;
    
    void Awake()
    {
        palyerDead = false;

        DontDestroyOnLoad(this);

        if (Instance != null)
        {
            Destroy(this.gameObject);
        }else
        {
            Instance = this;
        }

        
    }

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && palyerDead == true) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
       
        if(enemyList.transform.childCount == 0)
        {
            endLevel.SetActive(true);  
        }
        else
        {
            endLevel.SetActive(false);
        }

        //Debug.Log(enemyList.transform.childCount);
        
    }

    public void DestroyInMenu()
    {
        Destroy(this.gameObject);
    }
}

