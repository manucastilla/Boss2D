using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public AudioClip jumpSFX;
    public float speed = 0.2f;
    public float jumpSpeed = 6;
    public Rigidbody2D rb;
    public bool ground;
    public Vector3 StartPosition;
    public Camera camera1;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    void Start()
    {
        ground = true;
        StartPosition = transform.position;
    }

    void FixedUpdate()
    {
        //transform.Translate(Vector2.right * (Time.deltaTime * speed));
        transform.localPosition += new Vector3(speed, 0, 0);
        camera1.transform.localPosition += new Vector3(speed, 0, 0);
    }


    // Update is called once per frame
    void Update()
    {
        // Debug.Log(transform.position.x);
        // Debug.Log(camera1.transform.position.x);
        if (transform.position.x + 10 < camera1.transform.position.x)
        {
            Debug.Log("x");
            GameOver();
        }


        if (rb.transform.position.y < -0.5)
        {

            // Debug.Log(this.transform.position.x);
            GameOver();
        }

        if (Input.GetButton("Jump"))
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

    protected void jump()
    {
        // rb.velocity = Vector2.up * jumpSpeed;
        rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        // rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Infra")
        {
            ground = false;


        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Infra")
        {
            ground = true;

        }
        if (col.gameObject.tag == "Spike")
        {
            Respawn();
        }

    }

    public void Respawn()
    {
        transform.position = StartPosition;
    }
}
