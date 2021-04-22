using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroy : MonoBehaviour
{
    public GameObject DestructionPoint;
    // Start is called before the first frame update
    void Start()
    {
        DestructionPoint = GameObject.Find("PlatformDestructionPoint");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < DestructionPoint.transform.position.x){
            Destroy(gameObject);
        }
        
    }
}
