using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RockNCoinMoving : MonoBehaviour
{
    [SerializeField]
    GameObject coinPrefab;
    [SerializeField]
    GameObject rockPrefab;
    [SerializeField]
    float rockNCoinSpeed = 4f;
    private void Start()
    {
        SpriteRenderer rockRenderer = rockPrefab.GetComponent<SpriteRenderer>();
        Vector3 reposition = new Vector3(rockRenderer.transform.position.x - 0.2f, rockRenderer.bounds.size.y - 2.3f, 0f);
        GameObject coin = Instantiate(coinPrefab, this.transform);
        coin.transform.position = reposition;
    }
    void Update()
    {
        transform.position += Vector3.left * rockNCoinSpeed * Time.deltaTime;

        if (transform.position.x <= -11.5f)
        { Destroy(gameObject); }
    }
}
