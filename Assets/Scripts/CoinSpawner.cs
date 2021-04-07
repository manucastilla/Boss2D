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

    void Start()
    {

        if (GameObject.FindWithTag("Infra"))
        {
            screenBounds = GameObject.FindWithTag("Infra").transform.position;
            spawnCoin();
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        int seconds = Mathf.FloorToInt(timer);
        if (GameObject.FindWithTag("Infra"))
        {
            screenBounds = GameObject.FindWithTag("Infra").transform.position;
            if (timer > 3)
            {
                Debug.Log("oie");
                spawnCoin();
                timer = 0;
            }

        }

    }

    private void spawnCoin()
    {
        Instantiate(coin, new Vector2(screenBounds.x + 30, Random.Range(1, 4)), Quaternion.identity);
        // x.transform.position = new Vector2(screenBounds.x + 30, Random.Range(1, 4));

    }


}