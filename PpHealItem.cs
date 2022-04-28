using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PpHealItem : Item
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().PpHeal(15);

            removeItems();
        }
    }
}
