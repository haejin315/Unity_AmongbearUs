using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mission5 : MonoBehaviour
{
    public Transform rotate, handle;
    public Color blue, red;

    Animator anim;
    PlayerCtrl playerCtrl_script;
    RectTransform rect_handle;
    MissionCtrl missionCtrl_script;

    bool isDrag, isPlay;
    float rand;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rect_handle = handle.GetComponent<RectTransform>();
        missionCtrl_script = FindObjectOfType<MissionCtrl>();

    }

    private void Update()
    {
        //�巡��
        if (isPlay)
        {
            if (isDrag)
            {
                handle.position = Input.mousePosition;
                rect_handle.anchoredPosition = new Vector2(184,
                    Mathf.Clamp(rect_handle.anchoredPosition.y, -195, 195));

                //�巡�� ��
                if (Input.GetMouseButtonUp(0))
                {
                    //�������� üũ
                    if (rect_handle.anchoredPosition.y > -5 && rect_handle.anchoredPosition.y < 5)
                    {
                        Invoke("MissionSuccess", 0.2f);
                        isPlay = true;
                    }

                    isDrag = false;
                }
            }
            rotate.eulerAngles = new Vector3(0, 0, 90 * rect_handle.anchoredPosition.y / 195);

            //�����緯 �� ����
            if (rect_handle.anchoredPosition.y > -5 && rect_handle.anchoredPosition.y < 5)
            {
                rotate.GetComponent<Image>().color = blue;
            }
            else
            {
                rotate.GetComponent<Image>().color = red;
            }
        }
    }
    //�̼� ����

    public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();

        //�ʱ�ȭ
        rand = 0;

        //����
        rand = Random.Range(-195, 195);
        while (rand < 10 && rand > -10)
        {
            rand = Random.Range(-195, 195);
        }
        rect_handle.anchoredPosition = new Vector2(184, rand);
        isPlay = true;
    }

    //������ư ������ ȣ��
    public void ClickCancle()
    {
        anim.SetBool("isUp", false);
        playerCtrl_script.MissionEnd();
    }

    // ������ ������ ȣ��
    public void ClikcHandle()
    {
        isDrag = true;
    }

    //�̼�5 �����϶� ȣ��� �Լ�
    public void MissionSuccess()
    {
        ClickCancle();
        missionCtrl_script.MissionSuccess(GetComponent<CircleCollider2D>());
    }
}