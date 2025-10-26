using UnityEngine;

public class RtanClickMove : MonoBehaviour
{
    [SerializeField]
    private float rtanSpeed = 1f;
    internal bool isMoving = false;
    internal Vector3 nextPosition;
    private Rigidbody rigidBody;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        if (rigidBody == null)
        { Debug.Log("RigidBody 2d를 추가하지 않았습니다."); }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 screenPosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            nextPosition = new Vector3(worldPosition.x, worldPosition.y, 0f);
            isMoving = true;
        }
        if (isMoving)
        { transform.position = Vector3.MoveTowards(transform.position, nextPosition, rtanSpeed * Time.deltaTime); }
        if (Mathf.Abs(transform.position.x - nextPosition.x) < 0.001f && Mathf.Abs(transform.position.y - nextPosition.y) < 0.001f)
        {
            nextPosition = transform.position;
            isMoving = false;
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            nextPosition = transform.position;
            rigidBody.velocity = Vector2.zero;
            rigidBody.angularVelocity = new Vector3(0f, 0f, 0f);
            isMoving = false;
        }
    }
}
