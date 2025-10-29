using UnityEngine;
public class Shield : MonoBehaviour//커서 위치에 따라 보는 방향을 정하는 클래스입니다.
{
    SpriteRenderer renderer;
    private void Awake()
    { renderer = GetComponent<SpriteRenderer>(); }
    void Update()
    {
        Vector2 curserPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = curserPosition;
        FacedDirection();
    }
    void FacedDirection()
    {
        if (transform.position.x >= 0)
        { renderer.flipX = false; }
        else if (transform.position.x <= 0)
        { renderer.flipX = true; }
    }
}
