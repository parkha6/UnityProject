using UnityEngine;
public class Shield : MonoBehaviour
{
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
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
