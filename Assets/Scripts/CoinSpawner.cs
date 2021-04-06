using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://www.youtube.com/watch?v=E7gmylDS1C4

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    public float time = 1f;

    private Vector3 screenBounds;

    void Start()
    {
        if (GameObject.FindWithTag("Infra"))
        {
            screenBounds = GameObject.FindWithTag("Infra").transform.position;
            StartCoroutine(coinWave());
        }

    }

    void Update()
    {
        if (GameObject.FindWithTag("Player"))
        {
            screenBounds = GameObject.FindWithTag("Player").transform.position;
        }

    }

    private void spawnCoin()
    {
        GameObject x = Instantiate(coin as GameObject);

        x.transform.position = new Vector2(screenBounds.x + 30, Random.Range(1, 4));

    }

    IEnumerator coinWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            spawnCoin();
        }
    }

}