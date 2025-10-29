using UnityEngine;
public class TrapFalling : MonoBehaviour//뼈오브젝트의 로직을 담당하는 클래스입니다.
{
    [SerializeField]
    float trapSize = 1.0f;
    SpriteRenderer renderer;
    void Start()
    {
        float x = Random.Range(-2.56f, 2.15f);
        float y = Random.Range(3.03f, 3.35f);
        transform.position = new Vector3(x, y);
        transform.localScale = new Vector2(trapSize,trapSize);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.RtanRainEnd("르탄이가 뼈에 맞아서 기절했어요.");
        }
    }
}
