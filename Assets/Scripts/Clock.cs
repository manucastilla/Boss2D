using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Clock : MonoBehaviour
{
    Text textComp;
    GameManager gm;
    private static float timer;
    private float deltatimer;
    // Start is called before the first frame update
    void Start()
    {
        deltatimer = Time.time;
        gm = GameManager.GetInstance();
        timer = 0;
        textComp = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string clockTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        textComp.text = $"Time: {clockTime}";


        if (Time.time - deltatimer > 4.0)
        {
            gm.points += 2;
            deltatimer = Time.time;
        }

    }
}
