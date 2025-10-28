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
            "���̾��, �ܰ� �մ�. �ڸ��� �����Դϴ�.",

"�����߾��. ������ ���� ��Ʈ������ Ǫ�ðھ��?",

"���� ���ðԿ�? ������ �� ����. �������ϰ�.",

"������ ���� �����Դϴ�! ���� ������ ���� ���ݸ� ���ܵμ���.",

"��, ���� ����! ��� ������ �ϳ� �� �帱�Կ�.",

"���� ��� ���� ä���帱�Կ�. ����� ������ ����� ä��ž���.",

"���õ� �� ������. �װ͸����ε� Ī���޾� ��������.",

"����� ������׿�. ���� ���� ������ ���ư� �ð��̿���.",

"�� ������. ������ �� ������ ������ �غ��� �����Կ�.",

"��, �������� ����� �ٽ� ���� ���� �ð��Դϴ�.",
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
