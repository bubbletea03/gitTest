using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected float _speed = 0;
    [SerializeField] protected const float speed = 2;

    [SerializeField] public bool genByEnemy = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init(Vector3 pos)
    {
        genByEnemy = true;

        transform.position = pos;
        _speed = speed;
    }

    public void Init(int lane)
    {
        genByEnemy = false;

        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.25f + (0.25f * lane), 1.2f, -Camera.main.transform.position.z));
        _speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    protected void Move()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }

    //몬스터 처치로 인해 드롭된 아이템이 아닌 아이템을 모두 제거
    public void removeItems()
    {
        if (this.genByEnemy == true)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
            for (int i = 0; i < items.Length; ++i)
            {
                if (items[i] != this.gameObject && items[i].GetComponent<Item>().genByEnemy == false)
                {
                    Destroy(items[i]);
                }
            }
            Destroy(this.gameObject);
        }
    }

    public void Delete()
    {
        Destroy(this.gameObject);
    }
}
