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
        Debug.Log("완성! :: 이거 버튼임");
        completePopUp.SetActive(true);
    }

    public void ReturnToBase()
    {
        Debug.Log("ReturnToBase :: 이전 위치로 돌아감");
        completePopUp.SetActive(false);
        dressUp.SetActive(true);
        inputPrice.SetActive(true);
    }

    public void DisplayObject()
    {
        Debug.Log("DisplayObject :: 전시 후 멀티게임 옷장에 옷이 등록됨");
    }

    void FittingRoom()
    {
        Debug.Log("FittingRoom :: 촬영하기 / 돌아가기");
        GameObject.Find("Canvas").SetActive(false);
    }
}
