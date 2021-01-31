using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
   
    float timer = 0f;
    Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerText = gameObject.GetComponent<Text>();
        

    }
    public void Update()
    {
        timerText.text = "Timer: " + Mathf.Round(timer);
        timer += Time.deltaTime;
       
    }

}

