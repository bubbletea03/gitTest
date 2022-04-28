using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] protected Damage damage;
    
    protected void GiveDamage(Entity entity)
    {
        entity.TakeDamage(damage);
    }
}
