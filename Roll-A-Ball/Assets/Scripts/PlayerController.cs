using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
 //object refs
    private Rigidbody rb;
    public GameObject player;
    public GameObject restart;
    public GameObject restartMid;
    public GameObject teleporter;
//floats and ints
    public float speed; 
    private int count;
    private int score;
    private int enemy;
    private int lives;
//Text
    public Text countText;
    public Text winText;
    public Text scoreText;
    public Text instructions;
    public Text instructions2;
    public Text hitText;
    public Text livesText;
//timers
    public float instructTimer;
    public float hitTimer;
//bool
    private bool isTeleported;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count= 0;
        enemy= 0;
        score= 0;
        lives= 3;
        isTeleported = false;
        SetCountText();
        SetScoreText();
        SetLivesText();
        winText.text = " ";
        hitText.text = " ";
        instructions.text = "Collect all of the Yellow cubes!";
        StartCoroutine(HideInstructions());
    }
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (score >= 12 + enemy && !isTeleported)
        {
            Teleport();
        }
    }

    void FixedUpdate()
    {
       float moveHorizontal =  Input.GetAxis ("Horizontal");
       float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count= count +1;
            score= score +1;
            SetScoreText();
            SetCountText();
        }
         if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            enemy = enemy + 3;
            score = score - 1;
            lives = lives - 1;
            SetScoreText();
            SetLivesText();
            SetHitText();
            
        }
        
    }
    void SetCountText()
    {
     countText.text = "Count: " + count.ToString();  
    
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 24 + enemy && enemy == 0)
     {
       winText.text = "Perfect!" ;
     } 
     if (score >= 24 + enemy && enemy >= 1)
     {
       winText.text = "All cubes Collected" ;
       instructions2.text = "Collect all cubes without hitting Red for a Perfect win.";
     } 
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
         if (lives == 0)
     {
       winText.text = "You Lost" ;
       player.SetActive(false);
       restart.SetActive(false);
       restartMid.SetActive(true);
     } 
    }

    void SetHitText()
    {
        if(lives >=1)
        {
            hitText.text = "You lost a life!";
            StartCoroutine(HideHitText());
        }
        
    }
    IEnumerator HideInstructions()
    {
        yield return new WaitForSeconds(instructTimer);
        instructions.text = " ";
        instructions2.text = " ";
    }

    IEnumerator HideHitText()
    {
        yield return new WaitForSeconds(hitTimer);
        hitText.text = " ";
    }
    void Teleport(){
            isTeleported = true;
            player.transform.position = teleporter.transform.position;
        }
}
