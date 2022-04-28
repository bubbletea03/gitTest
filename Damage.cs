using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Damage
{
    public float damage;
    public float knockbackPower;
    public float knockbackDuration;
    public Vector2 knockbackDirection;
    public float stunDuration;

    public Damage(float damage)
    {
        this.damage = damage;
        this.knockbackPower = 0;
        this.knockbackDuration = 0;
        this.knockbackDirection = Vector2.zero;
        this.stunDuration = 0;
    }

    public Damage(float damage, float stunDuration)
    {
        this.damage = damage;
        this.knockbackPower = 0;
        this.knockbackDuration = 0;
        this.knockbackDirection = Vector2.zero;
        this.stunDuration = stunDuration;
    }

    public Damage(float damage, float knockbackPower, float knockbackDuration, Vector2 knockbackDirection)
    {
        this.damage = damage;
        this.knockbackPower = knockbackPower;
        this.knockbackDuration = knockbackDuration;
        this.knockbackDirection = knockbackDirection;
        this.stunDuration = 0;
    }

    public Damage(float damage, float knockbackPower, float knockbackDuration, Vector2 knockbackDirection, float stunDuration)
    {
        this.damage = damage;
        this.knockbackPower = knockbackPower;
        this.knockbackDuration = knockbackDuration;
        this.knockbackDirection = knockbackDirection;
        this.stunDuration = stunDuration;
    }
}
