using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDescribe : MonoBehaviour
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
