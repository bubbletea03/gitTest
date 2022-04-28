using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] public float givingExp;

    [SerializeField] public Vector2 speed;

    [SerializeField] public Damage damage;

    private PlayerController playerCtrl;

    public override void Init()
    {
        base.Init();

        playerCtrl = FindObjectOfType<PlayerController>();
    }

    public override void Dead()
    {
        FindObjectOfType<PlayerController>().curExp += givingExp;

        base.Dead();
    }

    public override void TakeDamage(Damage dmg)
    {
        base.TakeDamage(dmg);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (playerCtrl.isGod == true)
                return;

            damage.damage *= 0.5f;
            collision.GetComponent<Entity>().TakeDamage(damage);
            Dead();
        }
        else if(collision.tag == "Border")
        {
            FindObjectOfType<PlayerController>().TakePpDamage(damage.damage * 0.33f);
            Delete();
        }
    }
}
