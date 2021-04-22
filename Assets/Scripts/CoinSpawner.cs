using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://www.youtube.com/watch?v=E7gmylDS1C4

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    public float time = 1f;
    public static float timer;
    private Vector3 screenBounds;
    private float checkRadius;
        private float speed = 0.17f;
    void Start()
    {
        checkRadius = 1.3f;

        if (GameObject.FindWithTag("Infra"))
        {
            screenBounds = GameObject.FindWithTag("Infra").transform.position;
            spawnCoin();
        }
    }

    void Update()
    {   
        screenBounds = transform.position;
        timer += Time.deltaTime;
        int seconds = Mathf.FloorToInt(timer);
     
            //screenBounds = GameObject.FindWithTag("Infra").transform.position;
            if (timer > 3)
            {
                spawnCoin();
                timer = 0;
            }

        

    }

    void FixedUpdate()
    {
        //transform.Translate(Vector2.right * (Time.deltaTime * speed));
        transform.localPosition += new Vector3(speed, 0, 0);
    }

    private void spawnCoin()
    {

        screenBounds.x = screenBounds.x + 30;
        var barrier = Physics2D.OverlapCircleAll(screenBounds, checkRadius);


        foreach (Collider2D colli in barrier) {
            //Debug.Log(colli.tag);
            if (colli.tag != "Barrier") {
                Instantiate(coin, new Vector2(screenBounds.x, Random.Range(3, 4)), Quaternion.identity);
                break;
            } else {
                Instantiate(coin, new Vector2(screenBounds.x, Random.Range(1, 4) + 2), Quaternion.identity);
                break;
            }
        } 
            
    }


}