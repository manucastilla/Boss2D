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
    // Start is called before the first frame update
    void Start()
    {
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
            distance = Random.Range(distanceMin, distanceMax);

            platformSelector = Random.Range(0, 4);

            if (counterDificulty >= 20) {
                platformSelector = Random.Range(0, platformList.Length);
            }

            
            counterDificulty += platformSelector;
            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] + distance, transform.position.y, transform.position.z);

            Instantiate(platformList[platformSelector], transform.position, transform.rotation);
        }
        
    }
}
