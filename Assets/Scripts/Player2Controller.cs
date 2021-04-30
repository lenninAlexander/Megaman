using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 50;
    public float upSpeed = 100;
    public Transform FirePoint;
    float totaltime;
    float totaltime1;
    double seconds;
    private bool puedoSaltar = false;
    //private int totaltime=5;
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb2d;
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;
    //public Text text;
    //private int Score = 0;
    private bool morir = false;
    //public GameObject rightBullet;
    //public GameObject leftBullet;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); // obtengo el objeto spriterenderer de Player
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        this.totaltime = 5f;
        this.totaltime1 = 3f;
        this.seconds = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        setIdleAnimation();

        if (Input.GetKey(KeyCode.RightArrow))
        {

            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            setRunAnimation();
            sr.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {

            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            setRunAnimation();
            sr.flipX = true;
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
         
            rb2d.velocity = Vector2.up * upSpeed;
            puedoSaltar = true;
            setJumpAnimation();
        }
        if (morir)
        {
            SceneManager.LoadScene("Perdiste");
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            setRunDisparandoAnimation();
            Instantiate(bullet, FirePoint.position, Quaternion.identity);
        }
        if (Input.GetKey(KeyCode.X))
        {
            totaltime1 -= Time.deltaTime;
            seconds = (int)(totaltime1 % 60);
            if(seconds<=0)
            {
                this.totaltime1 = 3f;
                this.seconds = 0.0f;
                setRunDisparandoAnimation();
                Instantiate(bullet2, FirePoint.position, Quaternion.identity);
            }
            

        }
        else
        {
            this.totaltime1 = 3f;
            this.seconds = 0.0f;
        }
       if (Input.GetKey(KeyCode.X))
        {
            totaltime -= Time.deltaTime;
            seconds = (int)(totaltime % 60);
            if (seconds <= 0)
            {
                this.totaltime = 5f;
                this.seconds = 0.0f;
                setRunDisparandoAnimation();
                Instantiate(bullet3, FirePoint.position, Quaternion.identity);
            }
          
        }
        else
        {
            this.totaltime = 5f;
            this.seconds = 0.0f;
        }
    }

    

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            puedoSaltar = true;
        }


        if (other.gameObject.layer == 9)
            SceneManager.LoadScene("Perdiste");
        if (other.gameObject.layer == 7)
        {
            morir = true;
        }
    }



    private void setRunAnimation()
    {
        animator.SetInteger("Estado", 1);
    }

    private void setJumpAnimation()
    {
        animator.SetInteger("Estado", 3);
    }

    private void setIdleAnimation()
    {
        animator.SetInteger("Estado", 0);
    }
    private void setRunDisparandoAnimation()
    {
        animator.SetInteger("Estado", 2);
    }
    //public void IncrementarPuntajeen100()
    //{
    //   Score += 100;
    //}
}
