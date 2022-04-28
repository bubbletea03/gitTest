using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGController : Enemy
{
    Vector2 targetPos;

    private void Awake()
    {
        Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = mainCam.ViewportToWorldPoint(new Vector2(Random.Range(0, 2), Random.Range(0, 2)));
        StartCoroutine(Move());
    } 

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move()
    {
        targetPos = mainCam.ViewportToWorldPoint(new Vector2(Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f)));

        float t = 0;
        Vector2 startPos = transform.position;

        while(t <= 1)
        {
            t += Time.deltaTime / speed.x;

            transform.position = Vector2.Lerp(startPos, targetPos, t);

            yield return null;
        }

        StartCoroutine(Move());
    }
}
