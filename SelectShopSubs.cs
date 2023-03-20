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

    string nickName = "���ڷ�";

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

    // �ڸ�
    void InitSubtitles()
    {
        dictSubtitles.Add(0, "�ȳ��ϼ���? ��Ÿ���� ������ ���� ���� ȯ���ؿ�.\n" +
            "�̰��� �ƹ�Ÿ�� ���̳� �Ź�, �Ǽ������� ����� ���̿���.\n" +
            "���� �ƹ�Ÿ�� �پ��� �м� �������� ����� �����̳���.");
        dictSubtitles.Add(1, "���ݺ��ʹ� �ƹ�Ÿ�� ���� ���� �������غ��� Ȱ���� �غ��ſ���.\n" + // ��ǻ�� �ִ� �ڸ��� �̵� �� ������ ���
            "��, �غ�Ƴ���?");
        dictSubtitles.Add(2, "���� � ���� ������ �� �� ���غ����?");
        dictSubtitles.Add(3, "���� �׸��� �׷� <color=red>" + nickName + "</color>���� ���� ����� ���Կ�.");
        dictSubtitles.Add(4, "���� � ���� ���� �� ������ �ϱ���"); // �հ��� ���̵�
        dictSubtitles.Add(5, "�������� �پ��� ������ Ȱ���ؼ� ���� �ٸ纸�°ſ���."); // �հ��� ���̵�
        dictSubtitles.Add(6, "�����׿�! ��.. ���� �ƽ����...\n" +
            "��ġ�� �� �Ϳ��� �������?"); // �հ��� ���̵�
        dictSubtitles.Add(7, "�ϼ��̿���! ���� ���� ���� �ϼ��Ǿ��׿�.\n" +
            "��� �������� �ϼ��Ǿ��ٸ� �ϼ���ư�� ��������.");
        dictSubtitles.Add(8, "�� �̹��� ���� ���� �����Ӱ� ���� �������� �ؿ�.\n" +
            "�������� �мǼ�� �� �� ������ ���� ���� ��������!");

        // ���� flow�̿ܿ� Ư�� key�� ��ġ �� value ����
    }

    // �ڸ� �ѱ��
    public void NextPage()
    {
        Id++;
        subtitle.text = dictSubtitles[Id];

        //SelectShop.instance.ScenarioFlow();
    }

}
