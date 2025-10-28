using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpaSpeech : MonoBehaviour
{
    [SerializeField]
    GameObject storeUi;
    [SerializeField]
    GameObject dialogUi;
    [SerializeField]
    Text dialogText;
    [SerializeField]
    Button button;
    [SerializeField]
    Button dialogButton;
    string[] spaDialog = new string[]
        {
            "오셨어요, 단골 손님. 자리는 이쪽입니다.",

"수고했어요. 오늘은 뭘로 스트레스를 푸시겠어요?",

"벌써 가시게요? 다음에 또 봐요. 몸조심하고.",

"오늘은 만취 금지입니다! 다음 모험을 위해 조금만 남겨두세요.",

"자, 여기 서비스! 계란 프라이 하나 더 드릴게요.",

"잔이 비면 제가 채워드릴게요. 당신의 마음은 당신이 채우셔야죠.",

"오늘도 잘 버텼어요. 그것만으로도 칭찬받아 마땅하죠.",

"어둠이 깊어졌네요. 이제 정말 집으로 돌아갈 시간이에요.",

"또 오세요. 다음엔 더 따뜻한 국물을 준비해 놓을게요.",

"자, 가벼워진 어깨로 다시 세상에 나갈 시간입니다.",
        };
    void Start()
    { 
        button.onClick.AddListener(OnClickTalking);
        dialogButton.onClick.AddListener(OnClickDialog);
    }

    // Update is called once per frame
    void OnClickTalking()
    {
        int randomNum = Random.Range(0, spaDialog.Length);
        storeUi.SetActive(false);
        dialogUi.SetActive(true);
        dialogText.text = spaDialog[randomNum];
    }
    void OnClickDialog() 
    {
        if (dialogUi.activeInHierarchy)
        { dialogUi.SetActive(false); }    
    }
}
