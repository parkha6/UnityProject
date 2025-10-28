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
    {
        if (GameManager.instance.CurrentStemina <= 0 && (sceneName == "RtanRain" || sceneName == "MyShield" || sceneName == "PlaffySurf"))
        {
            GameManager.instance.isReturn = true;
            if (GameManager.instance.gameScene == "RtanRain" || GameManager.instance.gameScene == "MyShield" || GameManager.instance.gameScene == "PlaffySurf")
            { SceneManager.LoadScene("MainMenu"); }
            return; 
        }
        SceneManager.LoadScene(sceneName); 
    }
}
