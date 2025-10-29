using UnityEngine;
public class OrderFix : MonoBehaviour//바위가 생성될때 Y좌표에 따라 스프라이트 표시순서를 바꾸는 클래스.
{
    float rtanHeight = -3.33f;
    SpriteRenderer sortingRender;
    private void Awake()
    { sortingRender = GetComponent<SpriteRenderer>(); }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= rtanHeight)
        { sortingRender.sortingOrder = 2; }
        else if (transform.position.y <= rtanHeight)
        { sortingRender.sortingOrder = 4; }
    }
}
