using UnityEngine;
public class MoveBackground : MonoBehaviour//앞으로 나가는 것 처럼 보이도록 배경을 움직이게 하는 클래스.
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
