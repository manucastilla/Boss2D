using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.2f;
    public float jumpSpeed = 6;
    public Rigidbody2D rb;
    public bool ground;
    public Vector3 StartPosition;
    public Camera camera1;
    // Start is called before the first frame update
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

        if (this.transform.position.x - 100 < camera1.transform.position.x)
        {
            Debug.Log("oie");
            // GameOver();
        }

        if (Input.GetButton("Jump"))
        {
            if (ground)
            {
                jump();
            }

        }

    }

    protected void jump()
    {
        // rb.velocity = Vector2.up * jumpSpeed;
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

        //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 0.3f), ForceMode2D.Impulse);
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
