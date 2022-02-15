using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public bool isJoyStick;
    public Image touchBtn, joyStickBtn;
    public Color mycolor;
    public PlayerCtrl playerCtrl_script;

    GameObject mainView, missionView;

    private void Start()
    {
        mainView = playerCtrl_script.mainView;
        missionView = playerCtrl_script.missionView;
    }
    //���� ��ư�� ������ ȣ��� �Լ�
    public void ClickSetting()
    {
        gameObject.SetActive(true);
        playerCtrl_script.isCantMove = true;
    }

    //�������� ���ư��� ��ư�� ������ ȣ��� �Լ�
    public void ClickBack()
    {
        gameObject.SetActive(false);
        playerCtrl_script.isCantMove = false;
    }

    //��ġ�̵��� ������ ȣ��� �Լ�
    public void ClickTouch()
    {
        isJoyStick = false;
        touchBtn.color = mycolor;
        joyStickBtn.color = Color.white;
    }

    //���̽�ƽ�� ������ ȣ��� �Լ�
    public void ClickJoyStick()
    {
        isJoyStick = true;
        joyStickBtn.color = mycolor;
        touchBtn.color = Color.white;
    }

    //���ӳ����� ������ ȣ��� �Լ�
    public void ClickQuit()
    {
        mainView.SetActive(true);
        missionView.SetActive(false);

        //ĳ���� ����
        playerCtrl_script.DestoryPlayer();
    }
}
