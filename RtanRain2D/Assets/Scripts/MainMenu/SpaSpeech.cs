using UnityEngine;
using UnityEngine.UI;
public class SpaSpeech : MonoBehaviour//상점에서 대화하기를 선택했을때 대화가 나오게 하는 클래스입니다.
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

"뭘로 스트레스를 푸시겠어요?",

"벌써 가시게요?\n다음에 또 봐요. 몸조심하고.",

"만취는 금지입니다!",

"자, 여기 서비스!",

"잔이 비면 제가 채워드릴게요.",

"오늘도 잘 버텼어요.",

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
