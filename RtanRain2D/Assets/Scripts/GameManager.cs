using UnityEngine;
using UnityEngine.UI;
/* 어려운 부분
 * 스크립트에서 씬 이름을 string으로 입력받아서 씬 이름에 따라서 처리하게 했는데 이러니까 계속 씬 이름을 입력해야 되서 enum을 쓰고 싶지만 어떻게 해야 enum을 사용해 에디터에서 이름을 인식하게 할지 모르겠다.  
 * 변수를 어떤 순서로 나열해야 좋을지 잘 모르겠다.
 * 코드에 입력받는 값 하나 넣은 뒤 스크립트가 들어간 곳을 찾는게 귀찮다.
 * ReadMe를 수정할때 바로 Main에 올라가니까 브랜치랑 병합할때 다시 메인을 받아야 해서 좀 귀찮다. ReadMe 수정을 바로 Main에다가 올려도 되는건지 모르겠다.
 * 작업하고 커밋을 올리니 ReadMe를 Main에서 받으니까 작업한게 날라가있어서 놀랐다. 
 * UI하나 고쳤더니 다른 씬에 있는 똑같은 UI도 고쳐야 되서 귀찮았다. (UI를 프리팹으로 만들면 되려나?)
 * 모바일 크기에선 잘 나오던 텍스트가 Free Aspect에서는 화질이 깨져서 놀랐다. Free Aspect 해상도의 기준을 잘 모르겠다.
*/
public enum SceneName //단어 자동완성용 
{
    MainMenu,
    RtanRain,
    MyShield,
    FlappySurf
}
public class GameManager : MonoBehaviour
{
    //TODO:MyShield 종료키에다가 변수 초기화 함수를 달아놓은 상태임 나중에 지워야 한다.
    public static GameManager instance;
    [SerializeField]
    Text levelText;
    [SerializeField]
    Image expBar;
    [SerializeField]
    Image steminaBar;
    [SerializeField]
    GameObject warningUi;//스테미나 없을 때 나오는 창
    internal bool isReturn = false;
    [SerializeField]
    GameObject endUI;//끝났을때 나오는 UI창을 넣는 자리
    [SerializeField]
    Text endText;//끝났을때 표시되는 메세지를 넣는 자리
    [SerializeField]
    Text showResultText;
    [SerializeField]
    Text timeText;//시간을 표시하는 텍스트를 넣는 자리
    [SerializeField]
    Text resultText;//끝났을 때 결과값을 표시하는 자리
    [SerializeField]
    internal string gameScene;//이 변수에 따라 어떤 코드를 재생할지 결정됨.
    [SerializeField]
    float timeWatch;//시간을 표시하는 변수
    [SerializeField]
    bool gameOver = false; //게임이 끝났는지 안 끝났는지 체크하는 공용 불리언.
    internal bool GameOver { get { return gameOver; } }
    string mainMenu = "MainMenu";
    string scene1 = "RtanRain";//여기서부터 부자가 되자 용 변수
    [SerializeField]
    GameObject coin;//코인 오브젝트
    [SerializeField]
    GameObject trap1;//뼈 오브젝트
    [SerializeField]
    GameObject trap2;//뼈 오브젝트
    [SerializeField]
    GameObject trap3;//뼈 오브젝트
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
    string scene3 = "FlappySurf";
    [SerializeField]
    Text surfDistanceText;
    float surfDistance = 0;
    [SerializeField]
    private float surfSpeed = 0f;
    int level = 1;
    int currentExp = 0;
    string levelKey = "userLevel";
    internal string expKey = "userExp";
    string steminaKey = "userStemina";
    internal int CurrentExp
    {
        get { return currentExp; }
        set
        {
            if (value <= 0)
            { value = 0; }
            currentExp = value;
        }
    }
    int exp { get { return 100 * level; } }
    int currentStemina = 100;
    internal int CurrentStemina
    {
        get { return currentStemina; }
        set
        {
            if (value < 0)
            { value = 0; }
            currentStemina = value;
        }
    }
    int stemina { get { return 100 * level; } }
    private void Awake()
    {
        Instance();
        HasKey();
    }
    void Start()
    {
        StartAll();
        if (gameScene == mainMenu)
        { StartMainMenu(); }
        else if (gameScene == scene1)
        {
            SetStemina();
            StartRtanRain();
        }
        else if (gameScene == scene2)
        {
            SetStemina();
            StartMyShield();
        }
        else if (gameScene == scene3)
        {
            SetStemina();
            StartFlappySurf();
        }
    }
    void Update()
    {
        //입력받은 게임씬의 이름에 맞춰서 업데이트를 재생
        if (gameScene == mainMenu)
        { UpdateMainMenu(); }
        else if (gameScene == scene1)
        { UpdateRtanRain(); }
        else if (gameScene == scene2)
        { UpdateMyShield(); }
        else if (gameScene == scene3)
        { UpdateFlappySurf(); }
    }
    //공용함수
    void Instance()//싱글톤용 함수
    {
        if (instance == null)
        { instance = this; }
    }
    void HasKey()//컴에 저장된 변수를 불러오는 함수
    {
        if (PlayerPrefs.HasKey(levelKey))
        { level = PlayerPrefs.GetInt(levelKey); }
        if (PlayerPrefs.HasKey(expKey))
        { currentExp = PlayerPrefs.GetInt(expKey); }
        if (PlayerPrefs.HasKey(steminaKey))
        { currentStemina = PlayerPrefs.GetInt(steminaKey); }
        if (PlayerPrefs.HasKey(firstKey))
        { allMoney = PlayerPrefs.GetInt(firstKey); }
        if (PlayerPrefs.HasKey(secondKey))
        { allChickenAmount = PlayerPrefs.GetInt(secondKey); }
    }
    void SetStemina()
    {
        --CurrentStemina;
        PlayerPrefs.SetInt(steminaKey, CurrentStemina);
    }
    void StartAll()//스타트 함수를 시작할때 공통적으로 들어가는 부분
    {
        Time.timeScale = 1.0f;
        gameOver = false;
    }
    void TimeStop()//시간을 멈추는 함수
    { Time.timeScale = 0.0f; }
    internal void QuitGame()//게임을 끝내는 함수
    { Application.Quit(); }
    //메인매뉴 함수
    void StartMainMenu()
    {
        moneyText.text = allMoney.ToString();
        levelText.text = level.ToString();
    }
    void UpdateMainMenu()
    {
        expBar.fillAmount = (float)currentExp / (float)exp;
        steminaBar.fillAmount = (float)currentStemina / (float)stemina;
        if (currentExp >= exp)
        {//레벨업 이펙트 넣고 싶다
            currentExp -= exp;
            ++level;
            currentStemina = stemina;
            PlayerPrefs.SetInt(levelKey, level);
            PlayerPrefs.SetInt(expKey, currentExp);
            levelText.text = level.ToString();
        }
        if (isReturn)
        {
            warningUi.SetActive(true);
            isReturn = false; 
        }
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
        { return; }
        if (timeWatch > 0f)
        {
            CoinRain();
            timeWatch -= Time.deltaTime;
        }
        else
        { RtanRainEnd("르탄이는 더 이상 달릴 힘이 없어요."); }

        timeText.text = timeWatch.ToString("N2");
    }
    void CoinRain()//코인을 떨어트리는 함수
    { Instantiate(coin); }
    void TrapDrop()//맞으면 죽는 함정을 떨어트리는 함수
    {
        int trapNum = Random.Range(0, 3);
        if (trapNum == 0)
        { Instantiate(trap1); }
        else if (trapNum == 1)
        { Instantiate(trap2); }
        else if (trapNum == 2)
        { Instantiate(trap3); }
    }
    internal void AddMoney(int money)//소지금이 누적되는 함수
    {
        getMoney += money;
        allMoney += money;
        moneyText.text = allMoney.ToString();
        resultText.text = getMoney.ToString();
    }
    internal void RtanRainEnd(string endMessage)//부자가 되자 게임을 끝내는 함수
    {

        endText.text = endMessage;
        if (getMoney <= 0)
        { showResultText.text = "Game Over"; }
        else if (getMoney > 0)
        { showResultText.text = "Earn Cash"; }
        gameOver = true;
        endUI.SetActive(true);
        TimeStop();
        PlayerPrefs.SetInt(firstKey, allMoney);
    }

    //통닭을 지켜라용 함수
    void StartMyShield()//통닭을 지켜라 시작 함수
    {
        InvokeRepeating("BatReveal", 0f, 1f);
        cookingText.text = "";
        ShowChicken();
        CheckEnd();
    }
    void UpdateMyShield()//통닭을 지켜라 업데이트 함수
    {
        if (!gameOver)
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
        { Instantiate(batTop); }
        else if (batDirection == 2)
        { Instantiate(batLeft); }
        else if (batDirection == 3)
        { Instantiate(batRight); }
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
        { cookingText.text = ""; }

        if (allChickenAmount == 1)
        { chickenImage.SetActive(true); }
        if (allChickenAmount == bagSize + 1)
        { chickenImage2.SetActive(true); }
        if (allChickenAmount == bagSize * 2 + 1)
        { chickenImage3.SetActive(true); }
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
            MyShieldEnd("가방이 가득 찼습니다.");
        }
    }
    internal void MyShieldEnd(string inputMessage)//통닭 지키기 게임을 끝내는 함수
    {
        endText.text = inputMessage;
        if (finishedChicken <= 0)
        { showResultText.text = "Game Over"; }
        else if (finishedChicken > 0)
        { showResultText.text = "Meal Ready"; }
        food.SetBool("eaten", true);
        Invoke("TimeStop", 0.5f);
        endUI.SetActive(true);
        gameOver = true;
        PlayerPrefs.SetInt(secondKey, allChickenAmount);
    }
    //서핑을 하자용 함수
    //TODO: 난이도가 서서히 올라가도록 돌의 사이즈를 분류해서 순차적으로 나오게 하면 좋을거 같다.
    void StartFlappySurf()
    { moneyText.text = allMoney.ToString(); }
    void UpdateFlappySurf()//서핑을 하자 업데이트 함수
    {
        if (!gameOver)
        {
            surfDistance += surfSpeed * Time.deltaTime;
            surfDistanceText.text = surfDistance.ToString("N0");
            resultText.text = surfDistance.ToString("N0");
        }
    }
    internal void FlappySurfEnd(string inputMessage)
    {
        CurrentExp += (int)Mathf.Round(surfDistance * 10);
        PlayerPrefs.SetInt(expKey, CurrentExp);
        endText.text = inputMessage;
        if (surfDistance <= 0)
        { showResultText.text = "Game Over"; }
        else if (surfDistance > 0)
        { showResultText.text = "Surf Done"; }
        TimeStop();
        endUI.SetActive(true);
        gameOver = true;
    }
}
