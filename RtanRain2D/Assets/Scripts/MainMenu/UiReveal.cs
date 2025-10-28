using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiReveal : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        { canvas.SetActive(true); }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        { canvas.SetActive(false); }
    }
}
