using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Results : MonoBehaviour
{
    float timer = 0f;
    Text resultsText;
    // Start is called before the first frame update
    void Start()
    {
        resultsText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        
    }
}
