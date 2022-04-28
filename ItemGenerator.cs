using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] itemArr;

    private void Start()
    {
        ThreeItemsGeneration();
    }

    List<int> indexArr = new List<int>();
    int itemIndex;

    public void ThreeItemsGeneration()
    {
        indexArr.Clear();

        for(int i = 0; i < 3; ++i)
        {
            itemIndex = Random.Range(0, itemArr.Length);

            OverlapCheck();

            indexArr.Add(itemIndex);

            Instantiate(itemArr[itemIndex]).GetComponent<Item>().Init(i);
        }
    }

    void OverlapCheck()
    {
        for (int j = 0; j < indexArr.Count; ++j)
        {
            if (itemIndex == indexArr[j])
            {
                itemIndex = Random.Range(0, itemArr.Length);
                OverlapCheck();
            }
        }
    }

    public void ItemGeneration(Vector3 pos)
    {
        int itemIndex = Random.Range(0, itemArr.Length);
        Instantiate(itemArr[itemIndex]).GetComponent<Item>().Init(pos);
    }
}
