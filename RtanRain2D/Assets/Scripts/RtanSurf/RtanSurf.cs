using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using RtanMetaverse;
using UnityEngine.EventSystems;

namespace RtanMetaverse
{
    public class RtanSurf : MonoBehaviour
    {

        class RtanJump
        {
            //서핑에 탄 르탄이가 손가락으로 클릭을 받으면 점프한다.
        }
        class Score
        {
            //르탄이가 장애물을 넘길때마다 점수를 받는다.
        }
        class BackgroundMove
        {
            //배경이 우에서 좌로 움직이는 것을 무한 반복한다.
        }
        class Obstarcle
        {
            //암초같은 장애물이 우측에서부터 랜덤으로 형성된다.
        }
        class floor
        {
            //르탄이가 떨어지지 않도록 막고 있을 바닥.
        }
        private Rigidbody2D rtanBody;
        private MoveBackground moveBackground;
        float rtanJumping = 0f;
        float RtanJumping
        {
            get { return rtanJumping; }
            set
            {
                if (value >= 10f)
                { value = 10f; }
                rtanJumping = value;
            }
        }
        Vector3 direction = new Vector3(0.5f, 1f, 0f);
        void Awake()//Awake는 MonoBehavior에서 생성자 역할을 한다.
        {
            rtanBody = GetComponent<Rigidbody2D>();//컴포넌트를 변수에 할당.
            if (rtanBody == null)//방어코드
            { Debug.Log("RigidBody2D를 서핑 르탄이한테 달지 않았습니다."); }
            moveBackground = FindAnyObjectByType<MoveBackground>();
        }
        void Update()
        {
            if (transform.position.x > -1.2f)//재사용할지는 모르니까 일단 메서드로 빼지는 말자.
            { transform.position += Vector3.left * moveBackground.cameraSpeed * Time.deltaTime; }
            else if (transform.position.x < -1.2f)
            { transform.position += Vector3.right * moveBackground.cameraSpeed * Time.deltaTime; }
            if (Input.GetMouseButtonDown(0))
            { RtanJumping += 5f; }
            else if (Input.GetMouseButton(0))//누르는 시간동안 점프력 축척
            { RtanJumping += 1f * (Time.deltaTime * 10f); }
            else if (Input.GetMouseButtonUp(0))//버튼을 떼는 순간 점프. ForceMode2D로 질량이 계산되게 했다.
            {
                rtanBody.AddForce(direction * RtanJumping, ForceMode2D.Impulse);
                rtanJumping = 0f;//TODO:뛴다음 점프 초기화인데 난 물체에 닿았을때 초기화되게 하고 싶긴 함.
            }//오 이렇게 메서드 쓰는구나.
        }
    }
}
