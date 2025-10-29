using UnityEngine;
using UnityEngine.UI;
public class HideUi : MonoBehaviour//UI를 숨기거나 보이게 만드는 클래스
{
    [SerializeField]
    Button button;
    [SerializeField]
    GameObject canvas;
    [SerializeField]
    bool isShow = false;
    private void Awake()
    { button.onClick.AddListener(OnClickHideUi); }
    public void OnClickHideUi()
    { canvas.SetActive(isShow); }
}