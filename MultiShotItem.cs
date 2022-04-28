using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShotItem : Item
{
    int hello;
    int a;
    int b;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().fireProp.bulletLevel += 1;

            removeItems();
        }
    }
}
