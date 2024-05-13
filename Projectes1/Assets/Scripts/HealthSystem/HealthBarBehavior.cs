using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public Image healthFill;
    public Image background;

    public void ShowHealthFraction(float fraction)
    {
        healthFill.rectTransform.localScale = new Vector3(fraction,1,1);

        if(fraction < 1)
        {
            healthFill.enabled = true; 
            background.enabled = true;
        }
        else
        {
            healthFill.enabled = false; 
            background.enabled = false;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
