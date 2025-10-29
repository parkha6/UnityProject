using UnityEngine;
public class MoveCloud : MonoBehaviour//메인화면 배경의 구름을 움직이는 클래스
{
    [SerializeField]
    private float cloudSpeed = 1.0f;
    private Vector3 startPosition;
    void Start()
    { startPosition = transform.position; }
    void Update()
    {
        transform.position -= transform.right * cloudSpeed * Time.deltaTime;
        if (transform.position.x <= startPosition.x - 19.2f)
        { transform.position = startPosition; }
    }
}
