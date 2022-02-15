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
    //설정 버튼을 누르면 호출될 함수
    public void ClickSetting()
    {
        gameObject.SetActive(true);
        playerCtrl_script.isCantMove = true;
    }

    //게임으로 돌아가기 버튼을 누르면 호출될 함수
    public void ClickBack()
    {
        gameObject.SetActive(false);
        playerCtrl_script.isCantMove = false;
    }

    //터치이동을 누르면 호출될 함수
    public void ClickTouch()
    {
        isJoyStick = false;
        touchBtn.color = mycolor;
        joyStickBtn.color = Color.white;
    }

    //조이스틱을 누르면 호출될 함수
    public void ClickJoyStick()
    {
        isJoyStick = true;
        joyStickBtn.color = mycolor;
        touchBtn.color = Color.white;
    }

    //게임나가기 누르면 호출될 함수
    public void ClickQuit()
    {
        mainView.SetActive(true);
        missionView.SetActive(false);

        //캐릭터 삭제
        playerCtrl_script.DestoryPlayer();
    }
}
