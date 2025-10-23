using UnityEngine;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour
{
    public string sceneName;
    public void RetryGame()
    {
        SceneManager.LoadScene(sceneName);
    }

}
