using UnityEngine;

public class RtanClickMove : MonoBehaviour
{
    [SerializeField]
    private float rtanSpeed = 1f;
    internal bool isMoving = false;
    internal Vector3 nextPosition;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;
    private Animator walkAnimator;
    private void Awake()
    {
        walkAnimator = GetComponent<Animator>();
        if (walkAnimator == null)
        { Debug.Log("No animator"); }
        rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody == null)
        { Debug.Log("not added RigidBody 2d"); }
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        { Debug.Log("no sprite"); }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 screenPosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            nextPosition = new Vector3(worldPosition.x, worldPosition.y, 0f);
            if (nextPosition.x < transform.position.x)
            { spriteRenderer.flipX = true; }
            else if (nextPosition.x > transform.position.x)
            { spriteRenderer.flipX = false; }
            isMoving = true;//?
        }
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, rtanSpeed * Time.deltaTime);
            walkAnimator.SetBool("isWalking", true);
        }
        if (Mathf.Abs(transform.position.x - nextPosition.x) < 0.001f && Mathf.Abs(transform.position.y - nextPosition.y) < 0.001f)
        {
            nextPosition = transform.position;
            walkAnimator.SetBool("isWalking", false);
            isMoving = false;
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        nextPosition = transform.position;
        walkAnimator.SetBool("isWalking", false);
        isMoving = false;
    }
}
