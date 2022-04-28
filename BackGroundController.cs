using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    float speed = 0.5f;
    float yOffset;
    [SerializeField] MeshRenderer rdr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rdr.material.mainTextureOffset = new Vector2(0, yOffset += speed * Time.deltaTime);
    }
}
