using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RtanMetaverse;
namespace RtanMetaverse
{
    public class MoveBackground : MonoBehaviour
    {
        internal float cameraSpeed = 3f;
        Vector3 beforeStart = new Vector3(25.25f, 0f, 0f);
        Vector3 returnPosition = new Vector3(-12.7f, 0f, 0f);
        void Update()
        {
            if (transform.position.x <= returnPosition.x)
            { transform.position = beforeStart; }
            else
            { transform.position += Vector3.left * cameraSpeed * Time.deltaTime; }
        }
    }
}
