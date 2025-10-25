using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class OrderFix : MonoBehaviour
{
    float rtanHeight = -3.33f;
    SpriteRenderer sortingRender;
    private void Awake()
    {
        sortingRender = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= rtanHeight)
        { sortingRender.sortingOrder = 2; }
        else if (transform.position.y <= rtanHeight)
        { sortingRender.sortingOrder = 4; }
    }
}
