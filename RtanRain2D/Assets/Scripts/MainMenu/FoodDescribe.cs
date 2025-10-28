using UnityEngine;
using UnityEngine.UI;

public class FoodDescribe : MonoBehaviour
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


    // Start is called before the first frame update
    void Start()
    {
        image.sprite = sprite;
        nameText.text = foodName;
        describeText.text = foodDescribe;
        steminaText.text = giveStemina.ToString();
        priceText.text = foodPrice.ToString();
    }
}
