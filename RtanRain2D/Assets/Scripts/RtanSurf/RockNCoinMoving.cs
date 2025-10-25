using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockNCoinMoving : MonoBehaviour
{
    [SerializeField]
    float rockNCoinSpeed = 4f;
    void Update()
    {
        transform.position += Vector3.left * rockNCoinSpeed * Time.deltaTime;

        if (transform.position.x <= -11.5f)
        { Destroy(gameObject); }
    }
}
