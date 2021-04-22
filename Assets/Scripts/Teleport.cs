using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject transformInto;


    void OnTrigerEnter2D(Collider2D coll)
    {
        GameObject player = Instantiate(transformInto);
        player.transform.localPosition = coll.transform.localPosition;
        // Camera.main.GetComponent<CameraClearFlags>().trg = player.transform;
        Destroy(coll.gameObject);
    }
}
