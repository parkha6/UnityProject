using UnityEngine;
public class TrapFalling : MonoBehaviour
{
    float trapSize = 1.0f;
    SpriteRenderer renderer;
    public Sprite trap1;
    public Sprite trap2;
    public Sprite trap3;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        float x = Random.Range(-2.56f, 2.15f);
        float y = Random.Range(3.03f, 3.35f);

        transform.position = new Vector3(x, y);

        int trapType = Random.Range(1, 4);

        if (trapType == 1)
        {
            trapSize = 3f;
            this.renderer.sprite = trap1;
        }
        else if (trapType == 2)
        {
            trapSize = 3f;
            this.renderer.sprite = trap2;
        }
        else if (trapType == 3)
        {
            trapSize = 3f;
            this.renderer.sprite = trap3;
        }
        transform.localScale = new Vector3(trapSize, trapSize);
    }

    // Update is called once per frame
    void Update()
    {

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
