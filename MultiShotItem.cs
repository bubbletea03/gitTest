using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShotItem : Item
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().fireProp.bulletLevel += 1;

            removeItems();
        }
    }
}
