using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeCreate : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        float rockScale = Random.Range(0.5f, 0.8f);
        transform.localScale = new Vector2(rockScale, rockScale);
    }
}
