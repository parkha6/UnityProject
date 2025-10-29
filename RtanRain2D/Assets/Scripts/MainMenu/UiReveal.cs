using UnityEngine;
public class UiReveal : MonoBehaviour//메인매뉴에서 오브젝트 근처에 다가갔을때 UI창이 뜨게 하는 클래스입니다.
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