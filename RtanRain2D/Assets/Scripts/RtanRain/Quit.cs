using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public void OnClickQuitButton()
    { SceneManager.LoadScene("MainMenu"); }
}
