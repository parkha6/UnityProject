using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    [SerializeField]
    private float cloudSpeed = 1.0f;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    { startPosition = transform.position; }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.right * cloudSpeed * Time.deltaTime;
        if (transform.position.x <= startPosition.x - 19.2f)
        { transform.position = startPosition; }
    }
}
