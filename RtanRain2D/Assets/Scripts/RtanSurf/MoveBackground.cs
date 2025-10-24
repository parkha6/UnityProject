using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RtanMetaverse;
public class MoveBackground : MonoBehaviour
{
    [SerializeField]
    internal float cameraSpeed = 4.5f;
    private float backgroundWidth;
    [SerializeField]
    private float returnXPosition = -12.5f;
    void Awake()
    { backgroundWidth = GetComponent<SpriteRenderer>().bounds.size.x; }
    void Update()
    {
        transform.position += Vector3.left * cameraSpeed * Time.deltaTime;
        if (transform.position.x <= returnXPosition)
        {
            Vector3 newPosition = new Vector3(
                transform.position.x + (backgroundWidth * 2f),
                transform.position.y,
                transform.position.z
            );
            transform.position = newPosition;
        }
    }
}
