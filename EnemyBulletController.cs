using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : Attack
{
    public bool isFire = false;

    public Vector2 direction;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Fire(Damage dmg, float speed, float range, float rot, Vector3 startPos)
    {
        isFire = true;

        damage = dmg;

        float movedDistance = 0;
        Vector2 movePos;

        transform.position = startPos;
        transform.eulerAngles = new Vector3(0, 0, rot);

        while(movedDistance <= range)
        {
            movePos = direction * speed * Time.deltaTime;

            transform.Translate(movePos);

            movedDistance += movePos.magnitude;

            yield return null;
        }

        Delete();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "Player":

                GiveDamage(collision.GetComponent<Entity>());

                Delete();

                break;
        }
    }

    void Delete()
    {
        Destroy(this.gameObject);
    }

}
