#define test
//#define release

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectShop : MonoBehaviour
{
    public static SelectShop instance = null;

    [SerializeField]
    GameObject spawnPoint01;
    [SerializeField]
    GameObject spawnPoint02;

    [SerializeField]
    GameObject player;
    GameObject instantiatedPlayer;

    [SerializeField]
    SelectShopSubs subs;

    [SerializeField]
    Transform pcZone;

    [SerializeField]
    GameObject editCanvas;

    [SerializeField]
    GameObject shopEdit;

    [SerializeField]
    GameObject Tutorial_Top;

    [SerializeField]
    GameObject Tutorial_Tool;

    [SerializeField]
    GameObject Tutorial_Patch;

    [SerializeField]
    GameObject Tutorial_Complete;

    [SerializeField]
    GameObject Tutorial_Thin;

    void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        instantiatedPlayer = Instantiate(player, spawnPoint01.transform.position, spawnPoint01.transform.rotation);
        instantiatedPlayer.name = "Player";
    }

    void Update()
    {
        if (subs.Id == 1) // PC존으로 이동
        {
            Debug.Log("ScenarioFlow");
            MyCharacterController.Instance.HoldControl(true);
            MyCharacterController.Instance.MoveToPosition(pcZone);
        }
        else if (subs.Id == 3)
        {
            Debug.Log("subs Id == 3");
            instantiatedPlayer.transform.position = spawnPoint02.transform.position;
            instantiatedPlayer.transform.rotation = spawnPoint02.transform.rotation;

            editCanvas.SetActive(true);
            shopEdit.SetActive(true);
        }
        else if (subs.Id == 4)
        {
            Debug.Log("subs Id == 4");
            Tutorial_Top.SetActive(true);
        }
        else if (subs.Id == 5)
        {
            Debug.Log("subs Id == 5");
            Tutorial_Top.SetActive(false);
            Tutorial_Thin.SetActive(true);
            Tutorial_Tool.SetActive(true);
        }
        else if (subs.Id == 6)
        {
            Debug.Log("subs Id == 6");
            Tutorial_Tool.SetActive(false);
            Tutorial_Patch.SetActive(true);
        }
        else if (subs.Id == 7)
        {
            Debug.Log("subs Id == 7");
            Tutorial_Patch.SetActive(false);
            Tutorial_Complete.SetActive(true);
        }
        else if (subs.Id == 8)
        {
            Debug.Log("subs Id == 8");
            Tutorial_Complete.SetActive(false);
        }


    }

    // 특정 시나리오 구간마다 실행되는 동작함수 예) 특정 포인트 이동 or 손가락 표시 등
    //public void ScenarioFlow()
    //{
    //    if(subs.Id == 1) // PC존으로 이동
    //    {
    //        MyCharacterController.instance.MoveToPosition(pcZone);
    //    }
    //}
}
