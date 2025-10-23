using UnityEngine;

public class Quit : MonoBehaviour
{
    public void OnClickQuitButton()
    {
        PlayerPrefs.DeleteAll();
        GameManager.instance.QuitGame();
    }
}
