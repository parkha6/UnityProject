using UnityEngine;
using UnityEngine.UI;
public class Restart : MonoBehaviour//디버그용 재시작버튼을 담당하는 클래스. 누르면 저장된 데이터가 모두 삭제됨.
{
    [SerializeField]
    Button button;
    private void Awake()
    { button.onClick.AddListener(OnButtonRestart); }
    void OnButtonRestart()
    { PlayerPrefs.DeleteAll(); }
}