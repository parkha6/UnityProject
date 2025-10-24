using UnityEngine;
namespace RtanMetaverse
{
    public class BatComing : MonoBehaviour
    {
        public float minRangeX;
        public float maxRangeX;
        public float minRangeY;
        public float maxRangeY;
        public float speed;
        public float minSize;
        public float maxSize;
        Vector3 targetPosition;
        bool flying = true;
        SpriteRenderer renderer;

        // Start is called before the first frame update
        void Start()
        {
            float x = Random.Range(minRangeX, maxRangeX);
            float y = Random.Range(minRangeY, maxRangeY);
            float size = Random.Range(minSize, maxSize);

            transform.position = new Vector3(x, y);
            transform.localScale = new Vector2(size, size);
            renderer = GetComponent<SpriteRenderer>();


            Application.targetFrameRate = 60;
            targetPosition = new Vector3(0f, -3.20f);
            flying = true;

        }

        // Update is called once per frame
        void Update()
        {
            moving();
            FacedDirection();
        }
        void moving()
        {
            if (flying)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
            else if (transform.position.y <= -5.7f)
            {
                Destroy(gameObject);
            }
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                flying = false;
            }
            else if (other.gameObject.CompareTag("Cooking"))
            {
                GameManager.instance.MyShieldEnd("박쥐가 통닭을 먹어버렸어요.");
            }
        }
        void FacedDirection()
        {
            if (transform.position.x >= 0)
            {
                renderer.flipX = false;
            }
            else if (transform.position.x <= 0)
            {
                renderer.flipX = true;
            }
        }
    }
}