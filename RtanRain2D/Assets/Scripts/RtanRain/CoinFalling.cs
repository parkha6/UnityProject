using UnityEngine;
public class CoinFalling : MonoBehaviour//코인의 로직을 정하는 클래스입니다.
{
    float coinSize = 1.0f;
    int coinScore = 0;
    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        float x = Random.Range(-2.56f, 2.15f);
        float y = Random.Range(3.03f, 3.35f);

        transform.position = new Vector3(x, y);

        int coinType = Random.Range(1, 4);

        if (coinType == 1)
        {
            coinSize = 3f;
            coinScore = 50;
            renderer.color = new Color(181f / 255f, 181f / 255f, 181f / 255f, 1f);
        }
        else if (coinType == 2)
        {
            coinSize = 5f;
            coinScore = 100;
            renderer.color = new Color(255f / 255f, 215f / 255f, 0f / 255f, 1f);
        }
        else if (coinType == 3)
        {
            coinSize = 7f;
            coinScore = 500;
        }
        transform.localScale = new Vector3(coinSize, coinSize);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.AddMoney(coinScore);
            Destroy(this.gameObject);
        }
    }
}
