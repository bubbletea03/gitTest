using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected float maxHp;
    [SerializeField] protected float curHp;

    [SerializeField] protected float stance;

    protected bool isKnockback = false;
    protected Coroutine corKnockback;

    protected Camera mainCam;

    protected SpriteRenderer spr;
    protected Color defaultColor;
    [SerializeField] protected Color hitColor;

    public bool isGod = false;

    public virtual void Init()
    {
        mainCam = Camera.main;

        curHp = maxHp;

        spr = GetComponent<SpriteRenderer>();
        defaultColor = spr.color;
    }

    public virtual void Heal(float healingHp)
    {
        curHp += healingHp;

        if(curHp > maxHp)
        {
            curHp = maxHp;
        }
    }

    public virtual void TakeDamage(Damage dmg)
    {
        if (isGod == true)
            return;

        curHp -= dmg.damage;

        if(curHp <= 0)
        {
            Dead();
        }

        Knockback(dmg.knockbackPower, dmg.knockbackDuration, dmg.knockbackDirection);

        StartCoroutine(Stun(dmg.stunDuration));

        StartCoroutine(HitFlash());
    }

    public virtual IEnumerator HitFlash()
    {
        spr.color = hitColor;
        yield return new WaitForSeconds(0.05f);
        spr.color = defaultColor;
    }

    public virtual void Knockback(float knockbackPower, float knockbackDuration, Vector2 knockbackDirection)
    {
        if (isKnockback == true)
            StopCoroutine(corKnockback);

        corKnockback = StartCoroutine(_Knockback(knockbackPower * (1 - stance), knockbackDuration, knockbackDirection));
    }

    protected IEnumerator _Knockback(float knockbackPower, float knockbackDuration, Vector2 knockbackDirection)
    {
        isKnockback = true;

        float t = 0;
        float movePos;

        while(t <= 1)
        {
            t += Time.deltaTime / knockbackDuration;

            movePos = Mathf.Lerp(knockbackPower, 0, t) * Time.deltaTime;

            transform.Translate(knockbackDirection * movePos);

            yield return null;
        }

        isKnockback = false;
    }

    protected IEnumerator Stun(float stunDuration)
    {
        Vector3 pos = transform.position;
        float t = 0;

        while(t < stunDuration)
        {
            t += Time.deltaTime;

            transform.position = pos;

            yield return null;
        }
    }

    public virtual void Dead()
    {
        Delete();
    }

    public virtual void Delete()
    {
        Destroy(this.gameObject);
    }
}
