using UnityEngine;
using UnityEngine.UI;
public class FoodDescribe : MonoBehaviour//음식설명을 UI에 배치하는 클래스
{
    [SerializeField]
    Image image;
    [SerializeField]
    Sprite sprite;
    [SerializeField]
    Text nameText;
    [SerializeField]
    string foodName;
    [SerializeField]
    Text describeText;
    [SerializeField]
    string foodDescribe;
    [SerializeField]
    Text steminaText;
    [SerializeField]
    int giveStemina;
    [SerializeField]
    Text priceText;
    [SerializeField]
    int foodPrice;
    void Start()
    {
        image.sprite = sprite;
        nameText.text = foodName;
        describeText.text = foodDescribe;
        steminaText.text = giveStemina.ToString();
        priceText.text = foodPrice.ToString();
    }
}
