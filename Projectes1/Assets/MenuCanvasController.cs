using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvasController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LevelManager.Instance?.DestroyInMenu();
    }

   
}
