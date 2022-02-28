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

    //미션 시작

    public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();

        //텍스트 초기화
        InputText.text = "";
        KeyCode.text = "";

        //키코드 랜덤 생성
        for(int i = 0; i<5; i++)
        {
            KeyCode.text += Random.Range(0, 10);
        }
    }

    //엑스버튼 누르면 호출
    public void ClickCancle()
    {
        anim.SetBool("isUp", false);
        playerCtrl_script.MissionEnd();
    }

    //숫자 버튼 누르면 호출
    public void ClickNumber()
    {
        if (InputText.text.Length <= 4)
        {
            InputText.text += EventSystem.current.currentSelectedGameObject.name;
        }

    }

    //삭제 버튼 누르면 호출
    public void ClickDelete()
    {
        if (InputText.text.Length != 0)
        {
            InputText.text = InputText.text.Substring(0, InputText.text.Length - 1);
        }
    }

    //체크 버튼 누르면 호출
    public void ClickCheck()
    {
        if(InputText.text == KeyCode.text)
        {
            MissionSuccess();
        }
    }

    //미션3 성공일때 호출될 함수
    public void MissionSuccess()
    {
        ClickCancle();
    }
}
