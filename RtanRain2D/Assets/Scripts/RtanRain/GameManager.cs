using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    //TODO:MyShield 종료키에다가 변수 초기화 함수를 달아놓은 상태임 나중에 지워야 한다.
    public static GameManager instance;
    [SerializeField]
    GameObject endUI;//끝났을때 나오는 UI창을 넣는 자리
    [SerializeField]
    Text endText;//끝났을때 표시되는 메세지를 넣는 자리
    [SerializeField]
    Text timeText;//시간을 표시하는 텍스트를 넣는 자리
    [SerializeField]
    Text resultText;//끝났을 때 결과값을 표시하는 자리
    [SerializeField]
    string GameScene;//이 변수에 따라 어떤 코드를 재생할지 결정됨.
    [SerializeField]
    float timeWatch;//시간을 표시하는 변수
    [SerializeField]
    bool gameOver = false; //게임이 끝났는지 안 끝났는지 체크하는 공용 불리언.
    internal bool GameOver { get { return gameOver; } }
    string scene1 = "RtanRain";//여기서부터 부자가 되자 용 변수
    [SerializeField]
    GameObject coin;//코인 오브젝트
    [SerializeField]
    GameObject trap;//뼈 오브젝트
    [SerializeField]
    Text moneyText;//은행계좌 잔액 표시용 텍스트
    static int allMoney;//지금까지 모은 돈의 액수
    int getMoney;//이번판에서 모은 돈의 액수
    string firstKey = "userMoneyAmount";//영구적으로 저장되는 소지금 변수 이름
    string scene2 = "MyShield";//여기서부터 고기를 지켜라 용 변수.
    [SerializeField]
    GameObject batTop;//위에서 오는 박쥐 오브젝트
    [SerializeField]
    GameObject batLeft;//좌에서 오는 박쥐 오브젝트
    [SerializeField]
    GameObject batRight;//우에서 오는 박쥐 오브젝트
    [SerializeField]
    GameObject chickenImage;//1번칸 통닭 이미지
    [SerializeField]
    GameObject chickenImage2;//2번칸 통닭 이미지
    [SerializeField]
    GameObject chickenImage3;//3번칸 통닭 이미지
    [SerializeField]
    Text cookingText;//고기가 구워지면 표시되는 텍스트
    [SerializeField]
    Text cookAmountText;//1번칸 고기수
    [SerializeField]
    Text cookAmountText2;//2번칸 고기수
    [SerializeField]
    Text cookAmountText3;//3번칸 고기수
    [SerializeField]
    Animator food;//고기가 구워지는 애니메이션
    [SerializeField]
    float roastedTimes;//치킨 한마리가 구워지는데 걸리는 시간
    [SerializeField]
    int bagSize;//한칸 당 들어갈 수 있는 치킨 마리수
    float cookingTime = 0.0f;//고기 한개를 굽기 시작한 시간을 측정하기 위한 변수
    static int allChickenAmount = 0;//지금까지 구운 고기의 수
    int finishedChicken = 0;//이번판에서 구운 고기의 수
    string secondKey = "userChickenAmount";//영구적으로 저장되는 고기 변수 이름
    private void Awake()
    {
        Instance();
        HasKey();
    }
    void Start()
    {
        StartAll();
        if (GameScene == scene1)
        {
            StartRtanRain();
        }
        else if (GameScene == scene2)
        {
            StartMyShield();
        }
    }
    void Update()
    {
        //입력받은 게임씬의 이름에 맞춰서 업데이트를 재생
        if (GameScene == scene1)
        {
            UpdateRtanRain();
        }
        else if (GameScene == scene2)
        {
            UpdateMyShield();
        }
    }
    //공용함수
    void Instance()//싱글톤용 함수
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void HasKey()//컴에 저장된 변수를 불러오는 함수
    {
        if (PlayerPrefs.HasKey(firstKey))
        {
            allMoney = PlayerPrefs.GetInt(firstKey);
        }
        if (PlayerPrefs.HasKey(secondKey))
        {
            allChickenAmount = PlayerPrefs.GetInt(secondKey);
        }
    }
    void StartAll()//스타트 함수를 시작할때 공통적으로 들어가는 부분
    {
        Time.timeScale = 1.0f;
        gameOver = false;
    }
    void TimeStop()//시간을 멈추는 함수
    {
        Time.timeScale = 0.0f;
    }
    public void QuitGame()//게임을 끝내는 함수
    {
        Application.Quit();
    }
    //부자가 되자용 함수
    void StartRtanRain()//부자가 되자 시작 함수
    {
        moneyText.text = allMoney.ToString();
        endUI.SetActive(false);
        InvokeRepeating("TrapDrop", 0f, 2f);
    }
    void UpdateRtanRain()//부자가 되자 업데이트 함수
    {
        if (gameOver)
        {
            return;
        }
        if (timeWatch > 0f)
        {
            CoinRain();
            timeWatch -= Time.deltaTime;
        }
        else
        {
            RtanRainEnd("르탄이는 더 이상 달릴 힘이 없어요.");
        }

        timeText.text = timeWatch.ToString("N2");
    }
    void CoinRain()//코인을 떨어트리는 함수
    {
        Instantiate(coin);
    }
    void TrapDrop()//맞으면 죽는 함정을 떨어트리는 함수
    {
        Instantiate(trap);
    }
    public void AddMoney(int money)//소지금이 누적되는 함수
    {
        getMoney += money;
        allMoney += money;
        moneyText.text = allMoney.ToString();
        resultText.text = getMoney.ToString();
    }
    public void RtanRainEnd(string endMessage)//부자가 되자 게임을 끝내는 함수
    {
        gameOver = true;
        endUI.SetActive(true);
        endText.text = endMessage;
        Time.timeScale = 0f;
        PlayerPrefs.SetInt(firstKey, allMoney);
    }

    //고기를 지켜라용 함수
    void StartMyShield()//고기를 지켜라 시작 함수
    {
        InvokeRepeating("BatReveal", 0f, 1f);
        cookingText.text = "";
        ShowChicken();
        CheckEnd();
    }
    void UpdateMyShield()//고기를 지켜라 업데이트 함수
    {
        if (gameOver)
        {

        }
        else
        {
            timeWatch += Time.deltaTime;
            cookingTime += Time.deltaTime;
            timeText.text = timeWatch.ToString("N2");
            FinishCooking();
        }
    }
    void BatReveal()//박쥐가 나타나는 함수
    {
        int batDirection = Random.Range(1, 4);
        if (batDirection == 1)
        {
            Instantiate(batTop);
        }
        else if (batDirection == 2)
        {
            Instantiate(batLeft);
        }
        else if (batDirection == 3)
        {
            Instantiate(batRight);
        }
    }
    void FinishCooking()//통닭을 굽는 함수
    {
        if (cookingTime >= roastedTimes)
        {
            cookingTime = 0f;
            cookingText.text = "통닭이 다 구워졌다!";
            ++finishedChicken;
            ++allChickenAmount;
            ShowChicken();
            CheckEnd();
            resultText.text = finishedChicken.ToString();
        }
        else if (cookingTime >= 5.0f && cookingTime <= roastedTimes)
        {
            cookingText.text = "";
        }

        if (allChickenAmount == 1)
        {
            chickenImage.SetActive(true);
        }
        if (allChickenAmount == bagSize + 1)
        {
            chickenImage2.SetActive(true);
        }
        if (allChickenAmount == bagSize * 2 + 1)
        {
            chickenImage3.SetActive(true);
        }
    }
    void ShowChicken()//치킨수를 인벤창에 보여주는 함수
    {
        int carculateChicken = 0;
        if (allChickenAmount >= 1)
        {
            if (allChickenAmount <= bagSize)
            {
                cookAmountText.text = allChickenAmount.ToString();
            }
            else if (allChickenAmount <= bagSize * 2)
            {
                carculateChicken = allChickenAmount - bagSize;
                cookAmountText.text = bagSize.ToString();
                cookAmountText2.text = carculateChicken.ToString();
            }
            else if (allChickenAmount <= bagSize * 3)
            {
                carculateChicken = allChickenAmount - (bagSize * 2);
                cookAmountText.text = bagSize.ToString();
                cookAmountText2.text = bagSize.ToString();
                cookAmountText3.text = carculateChicken.ToString();
            }
        }
        if (allChickenAmount <= 0)
        {
            chickenImage.SetActive(false);
            cookAmountText.text = "";
        }
        if (allChickenAmount <= bagSize)
        {
            chickenImage2.SetActive(false);
            cookAmountText2.text = "";
        }
        if (allChickenAmount <= bagSize * 2)
        {
            chickenImage3.SetActive(false);
            cookAmountText3.text = "";
        }

    }
    void CheckEnd()//인벤이 가득 찼을때 게임을 끝내기 위한 함수
    {
        if (allChickenAmount >= bagSize * 3)
        {
            cookingText.text = "가방이 가득 찼다!";
            MyShieldEnd("가방이 가득 차버렸어요.");
        }
    }
    public void MyShieldEnd(string inputMessage)//고기 지키기 게임을 끝내는 함수
    {
        endText.text = inputMessage;
        food.SetBool("eaten", true);
        Invoke("TimeStop", 0.5f);
        endUI.SetActive(true);
        gameOver = true;
        PlayerPrefs.SetInt(secondKey, allChickenAmount);
    }
}
