using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Clock : MonoBehaviour
{
    Text textComp;
    GameManager gm;
    public static float timer;
    // Start is called before the first frame update
    void Start()
    {
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

        if (timer > 4)
        {
            gm.points += 2;
            timer = 0;
        }

    }
}
