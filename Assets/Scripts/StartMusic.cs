using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         GameObject music = GameObject.FindGameObjectWithTag("Music");
         if (music){
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
         }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}