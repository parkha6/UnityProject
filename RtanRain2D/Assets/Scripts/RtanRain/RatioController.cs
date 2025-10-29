using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RatioController : MonoBehaviour//화면비의 가로가 일정이상 길어지면 중간앵커로 바꾸는 클래스입니다.
{
    [SerializeField]
    private float maxRatio = 2.144f;
    private RectTransform rectTransform;
    // Start is called before the first frame update
    void Awake()
    { rectTransform = GetComponent<RectTransform>(); }

    // Update is called once per frame
    void Start()
    {
        float currentRatio = (float)Screen.width / Screen.height;
        if (currentRatio > maxRatio)
        { SetAnchorToCenterBottom(); }
        else if(currentRatio < maxRatio)
        { SetAnchorToRightBottom(); }
    }
    private void SetAnchorToRightBottom()
    {
        rectTransform.anchoredPosition = new Vector3(-145f, 48f, 0f);
        rectTransform.anchorMin = new Vector2(1f, 0f);
        rectTransform.anchorMax = new Vector2(1f, 0f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
    }
    private void SetAnchorToCenterBottom()
    {
        rectTransform.anchoredPosition = new Vector3(1225f, 48f, 0f);
        rectTransform.anchorMin = new Vector2(0.5f, 0f);
        rectTransform.anchorMax = new Vector2(0.5f, 0f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
    }
}
