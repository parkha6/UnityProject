using UnityEngine;
using UnityEngine.UI;
public class ShowDescribe : MonoBehaviour//상점에서 음식 아이콘을 클릭했을때 설명이 나오게 하는 클래스입니다.
{
    [SerializeField]
    GameObject describeUi;
    [SerializeField]
    Button button;
    [SerializeField]
    int foodPrice;
    [SerializeField]
    int foodStemina;
    // Start is called before the first frame update
    void Awake()
    { button.onClick.AddListener(OnClickFood); }

    // Update is called once per frame
    void OnClickFood()
    {
        if (!describeUi.activeInHierarchy)
        { describeUi.SetActive(true); }
        else if (describeUi.activeInHierarchy)
        {
            if (GameManager.allMoney >= foodStemina && GameManager.CurrentStemina < GameManager.Stemina)
            {
                GameManager.allMoney -= foodPrice;
                GameManager.CurrentStemina += foodStemina;
                PlayerPrefs.SetInt(GameManager.instance.firstKey, GameManager.allMoney);
                PlayerPrefs.SetInt(GameManager.instance.steminaKey, GameManager.CurrentStemina);
            }
        }

    }
}
