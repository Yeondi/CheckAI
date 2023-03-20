#define test
//#define release

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectShopSubs : MonoBehaviour
{
    public static SelectShopSubs Instance = null;

    [SerializeField]
    public int Id { set; get; }

    Dictionary<int, string> dictSubtitles = new Dictionary<int, string>();

    string nickName = "프뢰레";

    [SerializeField]
    TMP_Text subtitle;

    private void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        InitSubtitles();

        subtitle.text = dictSubtitles[Id];
    }

    void Start()
    {
    }

    void Update()
    {
#if test
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Disabled?");
            if (MyCharacterController.Instance.GetComponent<PlayerInput>().actions.enabled == true)
                MyCharacterController.Instance.HoldControl(true);
            else
                MyCharacterController.Instance.HoldControl(false);

        }
#endif
    }

    // 자막
    void InitSubtitles()
    {
        dictSubtitles.Add(0, "안녕하세요? 메타버스 편집숍에 오신 것을 환영해요.\n" +
            "이곳은 아바타의 옷이나 신발, 악세서리를 만드는 곳이에요.\n" +
            "저는 아바타의 다양한 패션 아이템을 만드는 디자이너죠.");
        dictSubtitles.Add(1, "지금부터는 아바타의 옷을 직접 디자인해보는 활동을 해볼거에요.\n" + // 컴퓨터 있는 자리로 이동 후 나오는 대사
            "자, 준비됐나요?");
        dictSubtitles.Add(2, "먼저 어떤 옷을 디자인 할 지 정해볼까요?");
        dictSubtitles.Add(3, "이제 그림을 그려 <color=red>" + nickName + "</color>만의 옷을 만들어 볼게요.");
        dictSubtitles.Add(4, "먼저 어떤 옷을 만들 지 선택을 하구요"); // 손가락 가이드
        dictSubtitles.Add(5, "오른쪽의 다양한 도구를 활용해서 옷을 꾸며보는거에요."); // 손가락 가이드
        dictSubtitles.Add(6, "멋지네요! 음.. 뭔가 아쉬운걸...\n" +
            "패치로 더 귀엽게 만들어볼까요?"); // 손가락 가이드
        dictSubtitles.Add(7, "완성이에요! 정말 멋진 옷이 완성되었네요.\n" +
            "모든 디자인이 완성되었다면 완성버튼을 누르세요.");
        dictSubtitles.Add(8, "자 이번엔 도움 없이 자유롭게 옷을 만들어보도록 해요.\n" +
            "마지막엔 패션쇼에도 설 수 있으니 멋진 옷을 만들어보세요!");

        // 기존 flow이외엔 특정 key를 배치 후 value 조정
    }

    // 자막 넘기기
    public void NextPage()
    {
        Id++;
        subtitle.text = dictSubtitles[Id];

        //SelectShop.instance.ScenarioFlow();
    }

}
