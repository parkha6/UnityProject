using UnityEngine;

public class MovingSkull : MonoBehaviour
{
    bool right = false;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
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
                if (transform.position.x >= 0.3f)
                {
                    right = false;
                }
                else
                {
                    transform.position += Vector3.right * 0.005f;
                }
            }
            else if (right != true)
            {
                if (transform.position.x <= -0.3f)
                {
                    right = true;
                }
                else
                {
                    transform.position += Vector3.left * 0.005f;
                }
            }
        }
    }
}
