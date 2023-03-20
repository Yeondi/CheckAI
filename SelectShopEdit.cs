using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectShopEdit : MonoBehaviour
{
    [SerializeField]
    GameObject completePopUp;

    [SerializeField]
    GameObject dressUp;

    [SerializeField]
    GameObject inputPrice;

    bool isDressUp = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CompleteDesign()
    {
        Debug.Log("�ϼ�! :: �̰� ��ư��");
        completePopUp.SetActive(true);
    }

    public void ReturnToBase()
    {
        Debug.Log("ReturnToBase :: ���� ��ġ�� ���ư�");
        completePopUp.SetActive(false);
        dressUp.SetActive(true);
        inputPrice.SetActive(true);
    }

    public void DisplayObject()
    {
        Debug.Log("DisplayObject :: ���� �� ��Ƽ���� ���忡 ���� ��ϵ�");
    }

    void FittingRoom()
    {
        Debug.Log("FittingRoom :: �Կ��ϱ� / ���ư���");
        GameObject.Find("Canvas").SetActive(false);
    }
}
