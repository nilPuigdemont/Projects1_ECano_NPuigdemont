using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject restartText;
    public TMP_Text remainingEnemies;
    public TMP_Text currentBullets;
    private int totalEnemies;
    // Start is called before the first frame update
    
    void Start()
    {
        totalEnemies = LevelManager.Instance.enemyList.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
        }

        if (LevelManager.Instance.playerDead == true)
        {
            restartText.SetActive(true);
        }
        else
        {
            restartText.SetActive(false);
        }

        if(LevelManager.Instance.enemyList.transform.childCount != 0)
        {
            remainingEnemies.text = "Remaining Enemies : " + LevelManager.Instance.enemyList.transform.childCount + "/" + totalEnemies;

        }
        else
        {
            remainingEnemies.text = "Go to Next Level";
        }

        if(References.player.GetComponent<WeaponBehavior>().currentBullets <= 0)
        {
            currentBullets.text = "Reloading";
        }
        else
        {
            currentBullets.text = "Bullets :  " + References.player.GetComponent<WeaponBehavior>().currentBullets + " / " + References.player.GetComponent<WeaponBehavior>().maxBullets;
        }
        


    }
}
