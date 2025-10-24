using RtanMetaverse;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RockMoving : MonoBehaviour
{
    private MoveBackground moveBackground;

    void Awake()
    {
        moveBackground = FindAnyObjectByType<MoveBackground>();
        if (moveBackground == null)
        { Debug.Log("MoveBackground가 없습니다."); }
    }
    void Update()
    {
        transform.position += Vector3.left * moveBackground.cameraSpeed * Time.deltaTime;

        if (transform.position.x <= -10.5f)
        { Destroy(gameObject); }
    }
}
