using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField]
    Button button;
    private void Awake()
    { button.onClick.AddListener(OnButtonRestart); }
    void OnButtonRestart()
    { PlayerPrefs.DeleteAll(); }
}
