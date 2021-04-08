using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public AudioClip jumpSFX;
    public float speed = 0.2f;
    public float jumpSpeed = 1000;
    public Rigidbody2D rb;
    public bool ground;
    public Vector3 StartPosition;
    public Camera camera1;

    public Transform groundCheck;
    public float checkRadius;

    public LayerMask groundLayer;
    GameManager gm;
    float playerPosition;
    float JumpVelocity;
 

    // float JumpDampening = 0.1f;

    void Start()
    {
        ground = true;
        
        StartPosition = transform.position;
        playerPosition = StartPosition.x - camera1.transform.position.x;
        gm = GameManager.GetInstance();

        GameObject music = GameObject.FindGameObjectWithTag("Music");
        if (music)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
        }
    }

    void FixedUpdate()
    {
        //transform.Translate(Vector2.right * (Time.deltaTime * speed));
        transform.localPosition += new Vector3(speed, 0, 0);
        camera1.transform.localPosition += new Vector3(speed, 0, 0);

        //jump alternativo
        Vector3 pos = transform.position;

        // if (JumpVelocity != 0)
        // {
        //     pos.y += JumpVelocity;
        //     JumpVelocity -= JumpDampening;
        //     if (JumpVelocity <= 0)
        //     {
        //         rb.gravityScale = 5.0f;
        //         JumpVelocity = 0;
        //     }
        // }

        // transform.position = pos;
    }


    // Update is called once per frame
    void Update()
    {
        ground = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

       
        if (transform.position.x + 10 < camera1.transform.position.x)
        {
            GameOver();
        }


        if (rb.transform.position.y < -0.5)
        {
            GameOver();
        }
        
        if (Input.GetKeyDown("space"))
        {
            if (ground)
            {
                jump();
                AudioManager.PlaySFX(jumpSFX);
            }

        }

    }

    public void GameOver()
    {
        SceneManager.LoadScene("EndMenu");
    }

    public void jump()
    {
        // rb.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Force);
        rb.AddForce(Vector2.up * jumpSpeed);
        // JumpVelocity = 0.6f;
        // rb.gravityScale = 0.0f;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        //     if (col.gameObject.tag == "Barrier")
        //     {
        //         if (transform.position.x - camera1.transform.position.x < playerPosition)
        //         {
        //             transform.position.x += 3;
        //         }

        //     }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // if (col.gameObject.tag == "Infra")
        // {
        //     ground = true;

        // }
        if (col.gameObject.CompareTag("Spike"))
        {
            
            GameOver();
            
        }

    }

    // private void OnTriggerEnter2D(Collider2D col)
    // {
    //     if (col.gameObject.CompareTag("Coin"))
    //     {
    //         gm.points += 10;

    //     }
    // }


}
