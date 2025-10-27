using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiReveal : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {canvas.SetActive(true);}
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        { canvas.SetActive(false); } 
    }
}
