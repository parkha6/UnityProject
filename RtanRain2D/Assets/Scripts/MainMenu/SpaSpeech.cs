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
            "오셨어요, 단골 손님.\n자리는 이쪽입니다.",

"수고했어요.\n뭘로 스트레스를 푸시겠어요?",

"벌써 가시게요?\n다음에 또 봐요. 몸조심하고.",

"오늘은 만취 금지입니다!\n다음 모험을 위해 조금만 남겨두세요.",

"자, 여기 서비스!\n계란 프라이 하나 더 드릴게요.",

"잔이 비면 제가 채워드릴게요.",

"오늘도 잘 버텼어요.\n그것만으로도 칭찬받아 마땅하죠.",

"어둠이 깊어졌네요.\n집으로 돌아갈 시간이에요.",

"또 오세요. \n다음에도 준비해 놓을게요.",

"다시 세상에 나갈 시간입니다.",
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
