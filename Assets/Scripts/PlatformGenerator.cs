using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public Transform generationPoint;
    private float distance;
    private float widthPlatform;

    public float distanceMin;
    public float distanceMax;

    public GameObject[] platformList;
    private int platformSelector;
    private float[] platformWidths;
    private int counterDificulty;
    public GameObject greenPortal;
    private bool portalSpawned;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        portalSpawned = false;
        counterDificulty = 0;
        platformWidths = new float[platformList.Length];

        for(int i = 0; i<platformList.Length; i++) {
            platformWidths[i] = platformList[i].GetComponent<BoxCollider2D>().size.x;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x) {

            if(PlayerController.portal) {
                timer += Time.time;
            }
            

            //Randomize distance between platforms
            distance = Random.Range(distanceMin, distanceMax);

            //Randomize platforms
            platformSelector = Random.Range(0, 4);

            //Increase dificulty
            if (counterDificulty >= 20) {
                platformSelector = Random.Range(0, platformList.Length);
            }

            //Spawn pair of portals on smooth surface to active power up
            if(platformList[platformSelector].name == "PlatformSmall"){
                //If first portal not spawned yet
                if(!portalSpawned) {
                    //Chance of 40%
                    if(Random.Range(0,10) >= 6){
                        portalSpawned = true;
                        Instantiate(greenPortal, new Vector3(transform.position.x + platformWidths[platformSelector] + distance + 5, transform.position.y + 2.2f, transform.position.z), transform.rotation);
                    }
                } else {
                    //Power Up's duration time
                    if (timer > 10){
                        Instantiate(greenPortal, new Vector3(transform.position.x + platformWidths[platformSelector] + distance + 5, transform.position.y + 2.2f, transform.position.z), transform.rotation);
                        timer = 0;
                        portalSpawned = false;
                    }
                }
            }


            
            counterDificulty += platformSelector;
            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] + distance, transform.position.y, transform.position.z);

            Instantiate(platformList[platformSelector], transform.position, transform.rotation);
        }
        
    }
}
