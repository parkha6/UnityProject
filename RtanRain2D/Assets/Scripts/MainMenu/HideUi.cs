using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HideUi : MonoBehaviour
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

