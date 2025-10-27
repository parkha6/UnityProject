using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    [SerializeField]
    Button button;
    private void Awake()
    { button.onClick.AddListener(OnClickQuitButton); }
    public void OnClickQuitButton()
    { SceneManager.LoadScene(sceneName); }
}
