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
    public GameObject coin;
    public Transform groundCheck;
    public float checkRadius;

    public LayerMask groundLayer;
    GameManager gm;
    float playerPosition;
    float JumpVelocity;

    public static bool portal;
    SpriteRenderer sprite;

    void Start()
    {
        portal = false;
        ground = true;

        StartPosition = transform.position;
        playerPosition = StartPosition.x - camera1.transform.position.x;
        gm = GameManager.GetInstance();

        sprite = GetComponent<SpriteRenderer>();

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

    IEnumerator Colour()
    {
        for (var n = 0; n < 100; n++)
        {
            sprite.material.color = Color.white;
            yield return new WaitForSeconds(.1f);
            sprite.material.color = Color.green;
            yield return new WaitForSeconds(.1f);
        }
        sprite.material.color = Color.white;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("EndMenu");
    }

    public void jump()
    {
        rb.AddForce(Vector2.up * jumpSpeed);
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Spike"))
        {

            GameOver();

        }

        if (col.gameObject.CompareTag("Portal"))
        {
            portal = !portal;
            if (portal)
            {
                StartCoroutine(Colour());
            }

        }

    }


}
