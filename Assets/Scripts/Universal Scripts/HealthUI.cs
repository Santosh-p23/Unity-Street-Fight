using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour
{
    private Image health_UI;

    void Start()
    {
        health_UI = GameObject.FindWithTag(Tags.HEALTH_UI).GetComponent<Image>(); 
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void DisplayHealth(float value)
    {
        value /= 100;
        if(value < 0f)
        {
            value = 0f;
        }

        health_UI.fillAmount = value;
    }
}
