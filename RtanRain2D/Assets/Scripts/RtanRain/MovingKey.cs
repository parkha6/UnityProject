using UnityEngine;
public class MovingKey : MonoBehaviour//마우스키가 입력될 때 마다 르탄이가 걷는 방향이 바뀌게 하는 클래스입니다.
{
    float speed = 0.03f;
    bool right = true;
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        renderer = GetComponent<SpriteRenderer>();//Get Component 함수에 spriteRenderer 제너럴 값을 넣어서 리턴받은 결과를 renderer변수에 입력한다.
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GameOver)
        { return; }
        else
        {
            if (right)
            {
                if (transform.position.x >= 2.68f || Input.GetMouseButtonDown(0))
                {
                    renderer.flipX = true;
                    right = false;

                }
                else
                { Move(Vector3.right, speed); }
            }
            else
            {
                if (transform.position.x <= -2.72f || Input.GetMouseButtonDown(0))
                {
                    renderer.flipX = false;
                    right = true;
                }
                else
                { Move(Vector3.left, speed); }
            }
        }
    }
    void Move(Vector3 direction, float inputSpeed)
    { transform.position += direction * inputSpeed; }
}
