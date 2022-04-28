using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBController : Enemy
{
    private bool passedPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        float xPos = Random.Range(0.2f, 0.8f);
        transform.position = mainCam.ViewportToWorldPoint(new Vector3(xPos, 1.1f, -mainCam.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if(passedPlayer == false)
        {
            Vector2 target;
            target = transform.position - PlayerController.playerTrans.position;
            transform.Translate(-target.normalized * speed.y * Time.deltaTime);

            if(transform.position.y < PlayerController.playerTrans.position.y)
                passedPlayer = true;
        }

        else
            transform.Translate(Vector2.down * speed.y * 1.5f * Time.deltaTime);
    }
}
