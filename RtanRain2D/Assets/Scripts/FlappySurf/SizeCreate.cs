using UnityEngine;
public class SizeCreate : MonoBehaviour//바위의 크기를 결정하는 클래스
{
    // Start is called before the first frame update
    void Awake()
    {
        float rockScale = Random.Range(0.5f, 0.8f);
        transform.localScale = new Vector2(rockScale, rockScale);
    }
}
