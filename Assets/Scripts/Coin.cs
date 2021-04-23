using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinSFX;
    GameManager gm;
    void Start()
    {
        gm = GameManager.GetInstance();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        AudioManager.PlaySFX(coinSFX);
        Destroy(gameObject);
        if(PlayerController.portal) {
            gm.points += 20;
        } else {
            gm.points += 10;
        }
        

    }

}
