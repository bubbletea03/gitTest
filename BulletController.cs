using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : Attack
{
    private Camera mainCam;
    private Vector2 waitingPos;

    public bool isFire = false;

    public Vector2 direction;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        mainCam = Camera.main;
        waitingPos = mainCam.ViewportToWorldPoint(new Vector2(2, -2));

        Rest();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Rest()
    {
        isFire = false;

        transform.position = waitingPos;
    }

    public IEnumerator Fire(Damage dmg, float speed, float range, float rot)
    {
        isFire = true;

        damage = dmg;

        float movedDistance = 0;
        Vector2 movePos;

        transform.position = PlayerController.playerTrans.position;
        transform.eulerAngles = new Vector3(0, 0, rot);

        while(movedDistance <= range)
        {
            movePos = direction * speed * Time.deltaTime;

            transform.Translate(movePos);

            movedDistance += movePos.magnitude;

            yield return null;
        }

        Rest();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "Enemy":

                GiveDamage(collision.GetComponent<Entity>());

                Rest();

                break;
        }
    }
}
