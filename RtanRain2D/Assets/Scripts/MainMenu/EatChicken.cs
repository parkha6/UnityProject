using UnityEngine;
using UnityEngine.UI;
public class EatChicken : MonoBehaviour//메인화면에서 인벤토리를 클릭하면 치킨을 먹게 하는 클래스
{
    [SerializeField]
    Button button;
    [SerializeField]
    int chickenNum = 1;
    int ChickenNum
    {
        get { return chickenNum; }
        set
        {
            if (value <= 0 || value >= 4)
            { value = 1; }
            chickenNum = value;
        }

    }
    private void Awake()
    { button.onClick.AddListener(OnClickButton); }
    void OnClickButton()
    {
        switch (ChickenNum)
        {
            case 1:
                if (GameManager.allChickenAmount > 0 && GameManager.CurrentExp < GameManager.Exp)
                {
                        --GameManager.allChickenAmount;
                    GameManager.CurrentExp += 10;
                    PlayerPrefs.SetInt(GameManager.instance.secondKey, GameManager.allChickenAmount);
                }
                break;
            case 2:
                if (GameManager.allChickenAmount > GameManager.instance.bagSize && GameManager.CurrentExp < GameManager.Exp)
                {
                    --GameManager.allChickenAmount;
                    GameManager.CurrentExp += 10;
                    PlayerPrefs.SetInt(GameManager.instance.secondKey, GameManager.allChickenAmount);
                }
                break;
            case 3:
                if (GameManager.allChickenAmount > GameManager.instance.bagSize * 2 && GameManager.CurrentExp < GameManager.Exp)
                {
                    --GameManager.allChickenAmount;
                    GameManager.CurrentExp += 10;
                    PlayerPrefs.SetInt(GameManager.instance.secondKey, GameManager.allChickenAmount);
                }
                break;
            default:
                break;
        }
    }
}
