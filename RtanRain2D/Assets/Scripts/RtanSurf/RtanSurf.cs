using UnityEngine;

namespace RtanMetaverse
{
    public class RtanSurf : MonoBehaviour
    {
        [SerializeField]
        private GameObject wave;
        private Rigidbody2D rtanBody;
        private MoveBackground moveBackground;
        private Vector3 wavePosition = new Vector3(0f, 0f, 0f);
        float rtanJumping = 0f;
        public float RtanJumping
        {
            get { return rtanJumping; }
            set
            {
                if (value >= 8f)
                { value = 8f; }
                rtanJumping = value;
            }
        }
        Vector3 direction = new Vector3(0.2f, 1.2f, 0f);
        void Awake()//Awake는 MonoBehavior에서 생성자 역할을 한다.
        {
            rtanBody = GetComponent<Rigidbody2D>();//컴포넌트를 변수에 할당.
            if (rtanBody == null)//방어코드
            { Debug.Log("RigidBody2D를 서핑 르탄이한테 달지 않았습니다."); }
            moveBackground = FindAnyObjectByType<MoveBackground>();
            if (moveBackground == null)
            { Debug.Log("MoveBackground가 없습니다."); }
        }
        void Update()
        {
            if (transform.position.y <= -2.7)
            {
                wavePosition.x = transform.position.x + 0.5f;
                wavePosition.y = -3.4f;
                switch (Random.Range(0, 2))
                {
                    case 0:
                        break;
                    case 1:
                        Instantiate(wave, wavePosition, Quaternion.identity);
                        Instantiate(wave, wavePosition, Quaternion.identity);
                        break;
                    default:
                        break;
                }
                if (transform.position.x > -1.6f)//재사용할지는 모르니까 일단 메서드로 빼지는 말자.
                { transform.position += Vector3.left * (moveBackground.cameraSpeed + 1f) * Time.deltaTime; }
                else if (transform.position.x < -1.7f)
                { transform.position -= Vector3.left * (moveBackground.cameraSpeed + 1f) * Time.deltaTime; }
                if (Input.GetMouseButtonDown(0))
                { RtanJumping += 3f; }
                else if (Input.GetMouseButton(0))//누르는 시간동안 점프력 축척
                { RtanJumping += 1f * (Time.deltaTime * 10f); }
                else if (Input.GetMouseButtonUp(0))//버튼을 떼는 순간 점프. ForceMode2D로 질량이 계산되게 했다.
                {
                    rtanBody.AddForce(direction * RtanJumping, ForceMode2D.Impulse);
                    rtanJumping = 0f;
                }//오 이렇게 메서드 쓰는구나.
            }
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                GameManager.instance.AddMoney(100);
                Destroy(other.gameObject);
            }
            if (other.gameObject.CompareTag("Rock"))
            { GameManager.instance.FlappySurfEnd("르탄이가 암석에 부딪혔어요."); }
        }
    }
}
