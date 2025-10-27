using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RtanMetaverse;
public class MoveBackground : MonoBehaviour
{
    [SerializeField]
    internal float cameraSpeed = 4.5f;
    [SerializeField]
    float endScreen = -100f;
    private float backgroundWidth;
    void Update()
    {
        transform.position += Vector3.left * cameraSpeed * Time.deltaTime;
        if (transform.position.x <= endScreen)
        { Destroy(gameObject); }
    }
}
