using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RtanMetaverse;
public class MoveBackground : MonoBehaviour
{
    internal float cameraSpeed = 5f;
    /*Vector3 beforeStart = new Vector3(25.25f, 0f, 0f);
    Vector3 returnPosition = new Vector3(-12.7f, 0f, 0f);
    void Update()
    {
        if (transform.position.x <= returnPosition.x)
        { transform.position = beforeStart; }
        else
        { transform.position += Vector3.left * cameraSpeed * Time.deltaTime; }
    }*/
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
