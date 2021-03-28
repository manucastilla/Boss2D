using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    public float jumpSpeed = 9;
    public Rigidbody2D rb;
    public bool ground;
    public Vector3 StartPosition;
    // Start is called before the first frame update
    void Start()
    {
        ground = true;
        StartPosition = transform.position;

        
        
    }

    void FixedUpdate(){
        //transform.Translate(Vector2.right * (Time.deltaTime * speed));
        transform.localPosition += new Vector3 (speed, 0, 0);
    }
   

    // Update is called once per frame
    void Update()
    {
        
        
        

        if(Input.GetButton("Jump")){
            if(ground){
                jump();
            }
            
        }
        
    }

    protected void jump() {
        rb.velocity = Vector2.up * jumpSpeed; 
        
        //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 0.3f), ForceMode2D.Impulse);
    }

    private void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.tag == "Infra") {
            ground = false;
            
            
        }

    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Infra") {
            ground = true;
            
        }
        if (col.gameObject.tag == "Spike"){
            Respawn();
        }

    }

    public void Respawn() {
        transform.position = StartPosition;
    }
}
