using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarBehaviour : MonoBehaviour
{

    public Image manaFill;
    public Image ManaMaxed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowManaFraction (float fraction)
    {
        manaFill.rectTransform.localScale = new Vector3(manaFill.transform.localScale.x, fraction); 

        if(fraction >=1)
        {
            ManaMaxed.gameObject.SetActive(true);
        }
        else
        {
            ManaMaxed.gameObject.SetActive(false);
        }
    
    }
}
