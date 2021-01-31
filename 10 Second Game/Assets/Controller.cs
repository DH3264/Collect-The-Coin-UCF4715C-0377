using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rd2d;
    float timer = 0f;
    public AudioClip SFX1;
    public AudioClip SFX2;
    public AudioClip Win;
    public AudioClip Lose;
    public AudioSource Source;
  

    public float speed;

    private int scoreValue = 0;
    public Text score;

    public Text ResultText;
    Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        ResultText.text = "";
        anim = GetComponent<Animator>();
        AudioSource backgroundMusic = gameObject.GetComponent<AudioSource>();
        backgroundMusic.PlayDelayed(3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));

        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetInteger("State", 2);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("State", 0);
        }

        timer += Time.deltaTime;

        

        if (Input.GetKey("Escape"))
        {
            Application.Quit();

        }



    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            Source.clip = SFX1;
            Source.Play();
            score.text = "Score: " + scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            if (scoreValue >= 2)
            {
                ResultText.text = "You Win!";
                Source.clip = Win;
                Source.Play();
                AudioSource backgroundMusic = gameObject.GetComponent<AudioSource>();
                backgroundMusic.Stop();

                Destroy(this);
            }
            
         }
        if (collision.collider.tag == "Wall")
        {
            Source.clip = SFX2;
            Source.Play();
            scoreValue -= 1;
            score.text = "Score: " + scoreValue.ToString();
            if (scoreValue <= 0)
            {
                ResultText.text = "You Lose!";
                Source.clip = Lose;
                Source.Play();
                AudioSource backgroundMusic = gameObject.GetComponent<AudioSource>();
                backgroundMusic.Stop();
                Destroy(this);
            }
        }
    }
    

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }
}