using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mission3 : MonoBehaviour
{
    public Text InputText, KeyCode;

    Animator anim;
    PlayerCtrl playerCtrl_script;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();    
    }

    //�̼� ����

    public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();

        //�ؽ�Ʈ �ʱ�ȭ
        InputText.text = "";
        KeyCode.text = "";

        //Ű�ڵ� ���� ����
        for(int i = 0; i<5; i++)
        {
            KeyCode.text += Random.Range(0, 10);
        }
    }

    //������ư ������ ȣ��
    public void ClickCancle()
    {
        anim.SetBool("isUp", false);
        playerCtrl_script.MissionEnd();
    }

    //���� ��ư ������ ȣ��
    public void ClickNumber()
    {
        if (InputText.text.Length <= 4)
        {
            InputText.text += EventSystem.current.currentSelectedGameObject.name;
        }

    }

    //���� ��ư ������ ȣ��
    public void ClickDelete()
    {
        if (InputText.text.Length != 0)
        {
            InputText.text = InputText.text.Substring(0, InputText.text.Length - 1);
        }
    }

    //üũ ��ư ������ ȣ��
    public void ClickCheck()
    {
        if(InputText.text == KeyCode.text)
        {
            MissionSuccess();
        }
    }

    //�̼�3 �����϶� ȣ��� �Լ�
    public void MissionSuccess()
    {
        ClickCancle();
    }
}
