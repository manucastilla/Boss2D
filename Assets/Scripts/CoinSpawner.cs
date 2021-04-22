using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://www.youtube.com/watch?v=E7gmylDS1C4

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    public GameObject player;
    Sprite sprite;

    SpriteRenderer spriteR;
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

        ChangeSprite(sprite);
        spriteR = coin.GetComponent<SpriteRenderer>();
        StartCoroutine(Colour());

        // if (PlayerController.portal)
        // {
        // Debug.Log("oie");
        // StartCoroutine(Colour());
        // }
        if (timer > 3)
        {
            spawnCoin();
            timer = 0;
        }


    }

    void ChangeSprite(Sprite coinSprite)
    {
        coin.GetComponent<SpriteRenderer>().sprite = coinSprite;
    }
    IEnumerator Colour()
    {
        for (var n = 0; n < 100; n++)
        {
            spriteR.material.color = Color.white;
            yield return new WaitForSeconds(.1f);
            // spriteR.material.color = new Color(173, 216, 230, 0.7f);
            spriteR.material.color = Color.red;
            yield return new WaitForSeconds(.1f);
        }
        spriteR.material.color = Color.white;
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


        foreach (Collider2D colli in barrier)
        {
            //Debug.Log(colli.tag);
            if (colli.tag != "Barrier")
            {
                Instantiate(coin, new Vector2(screenBounds.x, Random.Range(3, 4)), Quaternion.identity);
                break;
            }
            else
            {
                Instantiate(coin, new Vector2(screenBounds.x, Random.Range(1, 4) + 2), Quaternion.identity);
                break;
            }
        }

    }


}