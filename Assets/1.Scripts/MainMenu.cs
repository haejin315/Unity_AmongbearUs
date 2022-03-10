using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject missionView;

    //���� ���� ��ư�� ������ �� ȣ��
    public void ClickQuit()
    {
        //����Ƽ ������
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        //�ȵ���̵�
#else
Application.Quit();
#endif
    }

    //�̼� ��ư ������ ȣ��� �Լ�
    public void ClickMission()
    {
        gameObject.SetActive(false);
        missionView.SetActive(true);

        GameObject player = Instantiate(Resources.Load("Character"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        player.GetComponent<PlayerCtrl>().mainView = gameObject;
        player.GetComponent<PlayerCtrl>().missionView = missionView;

        missionView.SendMessage("MissionReset");
    }
}
