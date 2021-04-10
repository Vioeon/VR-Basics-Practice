using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public Image CursorGaugeImage; // public => inspector에 나타난다.
    private Vector3 ScreenCenter;
    private float GaugeTimer = 0.0f;
    private bool isTriggered = false;
    public Text TextUI;

    private Music ms;
    private Bgmctrl bgm;

    bool sound = false; //Object sound 상태

    void Start()
    {
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2); // 화면의 중심점
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter); // 화면의 중심 좌표로 ray를 쏴준다
        RaycastHit hit;
        CursorGaugeImage.fillAmount = GaugeTimer;

        ms = GameObject.Find("GazeCamera").GetComponent<Music>(); // Object Sound
        bgm = GameObject.Find("BGM").GetComponent<Bgmctrl>(); // BGM

        if (Physics.Raycast(ray, out hit, 100.0f)) // 100.0f : ray의 길이로 Ray 발사
        {
            if (hit.collider.tag != "Quad") // collider에 hit된 물체의 태그가 Quad가 아닐때
            {

                if (!sound) {
                     bgm.bgmvolume(0); // 배경음악 음소거
                     ms.PlaySound(hit.collider.name); // Object Sound PLAY
                 }
                sound = true;


                GaugeTimer += 1.0f / 3.0f * Time.deltaTime; //Time.deltaTime : 성능이 다른 기기에서 동일한 시간을 주기위해
                if (GaugeTimer >= 1.0f || isTriggered)
                {
                    TextUI.text = hit.collider.GetComponent<ObjectText>().text; // hit된 오브젝트의 ObjectText라는 Script에 있는 text를 출력
                    GaugeTimer = 0.0f;
                    isTriggered = false;
                }
            }
            else // Ray에 hit된 물체의 태그가 Quad 일 때 
            {
                GaugeTimer = 0.0f; //CursorGauge 초기화
                ms.PlaySound(""); // Object Sound STOP
                bgm.bgmvolume(0.3f); // BGM volume up
                sound = false;
            }
        }
        else // Ray를 발사했는데 hit가 안됐을 때
        {
            GaugeTimer = 0.0f; //CursorGauge 초기화
            ms.PlaySound(""); // Object Sound STOP
            bgm.bgmvolume(0.3f); // BGM volume up
            sound = false;
        }
    }
}
