using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayedPlay : MonoBehaviour
{

    private int scoreValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource backgroundMusic = gameObject.GetComponent<AudioSource>();
        backgroundMusic.PlayDelayed(3);

       
    }

    // Update is called once per frame
    void Update()
    {


    }

}