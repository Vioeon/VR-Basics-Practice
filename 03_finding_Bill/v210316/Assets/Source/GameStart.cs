using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    private Vector3 ScreenCenter;

    // Start is called before the first frame update
    void Start()
    {
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) //마우스 클릭 시
        {
            if (Physics.Raycast(ray, out hit, 100.0f)) // 화면 가운데로 Ray를 쏘고
            {
                if (hit.collider.tag == "GameStart") // hit된 물체의 태그가 Cube 이면 Scene 전환
                    SceneManager.LoadScene("Finding Bill");
            }
               
        }
    }
}
