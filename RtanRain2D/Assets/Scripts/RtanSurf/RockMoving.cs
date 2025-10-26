using RtanMetaverse;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RockMoving : MonoBehaviour
{
    [SerializeField]
    float rockSpeed = 4f;
    void Update()
    {
        transform.position += Vector3.left * rockSpeed * Time.deltaTime;

        if (transform.position.x <= -10.5f)
        { Destroy(gameObject); }
    }
}
