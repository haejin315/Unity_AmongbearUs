using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject joyStick, mainView, missionView;
    public Settings settings_script;

    Animator anim;

    public bool isCantMove;

    public float speed;


    private void Start()
    {
        anim = GetComponent<Animator>();

        Camera.main.transform.parent = transform;
        Camera.main.transform.localPosition = new Vector3(0, 0, -10);
    }
    private void Update()
    {
        if (isCantMove)
        {
            joyStick.SetActive(false);
        }
        else
        {
            Move();
        }
    }
    // 캐릭터 움직임 관리
    void Move()
    {
        if (settings_script.isJoyStick)
        {
            joyStick.SetActive(true);
        }
        else
        {
            joyStick.SetActive(false);

            // 클릭했는지 판단
            if (Input.GetMouseButton(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    Vector3 dir = (Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f)).normalized;

                    transform.position += dir * speed * Time.deltaTime;

                    anim.SetBool("isWalk", true);

                    // 왼쪽으로 이동
                    if (dir.x < 0)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                    // 오른쪽으로 이동
                    else
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                }
            }
            // 클릭하지 않는다면
            else
            {
                anim.SetBool("isWalk", false);
            }
        }
    }

    //캐릭터 삭제
    public void DestoryPlayer()
    {
        Camera.main.transform.parent = null;

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Mission")
        {
            print("미션 감지");
        }
    }
}
