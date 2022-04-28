using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private float[] genDelay;
    private float[] defaultGenDelay;
    [SerializeField] private float[] decDelay;

    //public bool doSpawn = true;

    private void Awake()
    {
        defaultGenDelay = new float[genDelay.Length];

        for (int i = 0; i < genDelay.Length; ++i)
        {
            defaultGenDelay[i] = genDelay[i];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < enemy.Length; ++i)
        {
            StartCoroutine(EnemyGeneration(i));
            StartCoroutine(DelayDec(i));
        }
    }

    // Update is called once per frame 
    void Update()
    {

    }

    IEnumerator EnemyGeneration(int enemyIndex)
    {
        while(true)
        {
            yield return new WaitForSeconds(genDelay[enemyIndex]);

           // if(doSpawn == true)
                Instantiate(enemy[enemyIndex]);
        }
    }

    IEnumerator DelayDec(int enemyIndex)
    {
        yield return new WaitForSeconds(10);

        //if(doSpawn == true)
            genDelay[enemyIndex] -= decDelay[enemyIndex];

        if (genDelay[enemyIndex] <= decDelay[enemyIndex] * 0.5f)
            yield break;

        StartCoroutine(DelayDec(enemyIndex));
    }
}
