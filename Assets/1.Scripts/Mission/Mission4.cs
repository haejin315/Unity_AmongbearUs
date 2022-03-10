using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mission4 : MonoBehaviour
{
    public Transform numbers;
    public Color blue;

    Animator anim;
    PlayerCtrl playerCtrl_script;
    MissionCtrl missionCtrl_script;

    int count;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        missionCtrl_script = FindObjectOfType<MissionCtrl>();
    }

    //�̼� ����

    public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();

        //�� �ʱ�ȭ
        for(int i = 0; i<numbers.childCount; i++)
        {
            numbers.GetChild(i).GetComponent<Image>().color = Color.white;
            numbers.GetChild(i).GetComponent<Button>().enabled = true;
        }

        //���� ���� ��ġ
        for(int i = 0; i< 10; i++)
        {
            Sprite Temp = numbers.GetChild(i).GetComponent<Image>().sprite;

            int rand = Random.Range(0, 10);
            numbers.GetChild(i).GetComponent<Image>().sprite = 
                numbers.GetChild(rand).GetComponent<Image>().sprite;
            numbers.GetChild(rand).GetComponent<Image>().sprite = Temp;
        }

        count = 1;
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
        if(count.ToString() == EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name)
        {
            // �� ����
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = blue;
            count++;

            // ���� ��ư ��Ȱ��ȭ
            EventSystem.current.currentSelectedGameObject.GetComponent<Button>().enabled = false;

            // ���� ����
            if(count == 11)
            {
                Invoke("MissionSuccess", 0.2f);
            }
        }
    }

    //�̼�3 �����϶� ȣ��� �Լ�
    public void MissionSuccess()
    {
        ClickCancle();
        missionCtrl_script.MissionSuccess(GetComponent<CircleCollider2D>());
    }
}
