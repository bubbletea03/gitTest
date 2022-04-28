using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCController : Enemy
{
    [SerializeField] float moveingDis;
    [SerializeField] float movedDis = 0;
    [SerializeField] bool firstMoveEnd = false;

    [SerializeField] GameObject bullet;

    Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        float xPos = Random.Range(0, 2) == 1 ? 1.2f : -0.2f;
        float yPos = Random.Range(0.7f, 0.9f);
        Vector2 pos = mainCam.ViewportToWorldPoint(new Vector2(xPos, yPos));
        transform.position = pos;

        moveDir = xPos <= 0 ? Vector2.right : Vector2.left;

        moveingDis = mainCam.ViewportToWorldPoint(new Vector2(Random.Range(0.8f, 1.3f), 0)).x;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if(firstMoveEnd == false)
        {
            transform.Translate(moveDir * speed.x * Time.deltaTime);
            movedDis += (moveDir * speed.x * Time.deltaTime).magnitude;
            if(movedDis >= moveingDis)
            {
                firstMoveEnd = true;
                Fire();
            }
        }
        else
        {
            transform.Translate(Vector2.down * speed.x * Time.deltaTime);
        }
    }

    void Fire()
    {
        EnemyBulletController go = Instantiate(bullet).GetComponent<EnemyBulletController>();
        go.direction = (PlayerController.playerTrans.position - transform.position).normalized;
        go.StartCoroutine(go.Fire(damage, 8, 10, 0, this.transform.position));
    }
}
