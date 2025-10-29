using UnityEngine;
public class RockMoving : MonoBehaviour//바위의 움직임을 결정하는 클래스. 필요없어졌었나? 판단이 안됨.
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
