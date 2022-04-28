using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Entity
{
    [SerializeField] private float characterSize = 0.02f;

    public static Transform playerTrans;

    public float score;
    public float maxExp;
    private float _curExp;

    public int hitGodDuration = 3;

    public float curExp
    {
        get { return _curExp; }
        set
        {
            _curExp = value;
            expBar.fillAmount = _curExp / maxExp;

            if(_curExp >= maxExp)
            {
                maxExp *= 1.1f;
                curExp = 0;
                itemGenerator.ThreeItemsGeneration();
            }
        }
    }
    [SerializeField] private Image expBar;
    [SerializeField] private ItemGenerator itemGenerator;

    [SerializeField] private Text hpText;
    [SerializeField] private Image hpBar;
    [SerializeField] private Text ppText;
    [SerializeField] private Image ppBar;

    public float maxPp = 100;
    public float curPp; 


    public MovementProperties moveProp;
    public FireProperties fireProp;

    private float fireTimer;

    public RingController ringCtrl;

    private void Awake()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        curExp = 0;

        playerTrans = this.transform;

        fireTimer = 0;
        moveProp.Init();
        fireProp.Init();

        fireProp.bulletArr = new List<BulletController>();        
        for(int i = 0; i < fireProp.bulletCount; ++i)
        {
            fireProp.bulletArr.Add(Instantiate(fireProp.bulletPrefeb).GetComponent<BulletController>());
            fireProp.bulletArr[i].direction = Vector2.up;
        }

        HpUIRenewal();
        PpUIrenewal();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    void Fire()
    {
        fireTimer += Time.deltaTime;

        if(fireTimer >= fireProp.fireDelay)
        {
            fireTimer = 0;
            //if (fireProp.bulletArr[fireProp.bulletNum].isFire == true)
            //    return;

            for(int i = 0; i <= fireProp.bulletLevel; ++i)
            {
                StartCoroutine(fireProp.bulletArr[fireProp.bulletNum].Fire(fireProp.damage, fireProp.bulletSpeed, fireProp.range, fireProp.bulletRot[fireProp.bulletLevel, i]));
                //Debug.Log("Fire");
                ++fireProp.bulletNum;

                if(fireProp.bulletNum >= fireProp.bulletCount)
                {
                    fireProp.bulletNum = 0;
                }
            }
        }
    }

    void Move()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * moveProp.speed * Time.deltaTime, 
                            Input.GetAxisRaw("Vertical") * moveProp.speed * Time.deltaTime, 0);

        Vector3 pos;
        pos = mainCam.WorldToViewportPoint(transform.position);

        if (pos.x < 0 + characterSize) pos.x = 0 + characterSize;
        else if (pos.x > 1 - characterSize) pos.x = 1 - characterSize;
        if (pos.y < 0 + characterSize) pos.y = 0 + characterSize;
        else if (pos.y > 1 - characterSize) pos.y = 1 - characterSize;

        transform.position = mainCam.ViewportToWorldPoint(pos);
    }

    public override void TakeDamage(Damage dmg)
    {
        base.TakeDamage(dmg);

        HpUIRenewal();
    }

    public override IEnumerator HitFlash()
    {
        int i = 0;

        isGod = true;

        while(i < hitGodDuration)
        {
            ++i;

            spr.color = hitColor;
            yield return new WaitForSeconds(0.2f);
            spr.color = defaultColor;
            yield return new WaitForSeconds(0.2f);
        }

        isGod = false;
    }

    public override void Heal(float healingHp)
    {
        base.Heal(healingHp);

        HpUIRenewal();
    }

    public void PpHeal(float healingPp)
    {
        curPp -= healingPp;

        if (curPp < 0)
            curPp = 0;

        PpUIrenewal();
    }

    public void TakePpDamage(float damage)
    {
        curPp += damage;

        if(curPp >= maxPp)
        {
            curPp = maxPp;
            //∞‘¿”ø¿§√§≤
        }

        PpUIrenewal();
    }

    public void HpUIRenewal()
    {
        hpText.text = "HP " + (int)curHp + " / " + (int)maxHp;
        hpBar.fillAmount = curHp / maxHp;
    }

    public void PpUIrenewal()
    {
        ppText.text = "PP " + (int)curPp + " / " + (int)maxPp;
        ppBar.fillAmount = curPp / maxPp;
    }
}
