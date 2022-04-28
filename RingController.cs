using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : Attack
{
    [SerializeField] private GameObject ringPrefab;

    public int ringLevel = -1;
    private int maxRingLevel = 3;

    private int[,] ringRot = new int[,] { { 0, 0, 0, 0 }, { 0, 180, 0, 0 }, { 0, 120, 240, 0 }, { 0, 90, 180, 270 } };

    private GameObject[] ringArr;

    private void Awake()
    {
        ringArr = new GameObject[4];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerController.playerTrans.position;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + (270 * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            GiveDamage(collision.GetComponent<Enemy>());
        }
    }

    public void AddRing()
    {
        ringLevel += 1;
        if(ringLevel > maxRingLevel)
        {
            ringLevel = maxRingLevel;
            return;
        }

        ringArr[ringLevel] = Instantiate(ringPrefab) as GameObject;
        ringArr[ringLevel].transform.SetParent(this.transform);

        for(int i = 0; i < ringLevel + 1; ++i)
        {

            ringArr[i].transform.localPosition = Vector3.zero;
            ringArr[i].transform.localEulerAngles = new Vector3(0, 0, ringRot[ringLevel, i]);
            ringArr[i].transform.Translate(Vector2.up * 2);
        }
    }
}
