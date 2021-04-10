using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GaugeSelection : MonoBehaviour
{
    public Image CursorGauge;
    float timeElapsed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Vector3 forward = this.transform.TransformDirection(Vector3.forward) * 1000;
        CursorGauge.fillAmount = timeElapsed / 2;

        if (Physics.Raycast(this.transform.position, forward, out hit))
        {
            if (hit.collider)
            {
                timeElapsed += Time.deltaTime;
                if (timeElapsed >= 2.0f)
                {
                    if (hit.collider.tag == "Ship01")
                        PlayerPrefs.SetInt("ship", 1);
                    else if (hit.collider.tag == "Ship02")
                        PlayerPrefs.SetInt("ship", 2);
                    else if (hit.collider.tag == "Ship03")
                        PlayerPrefs.SetInt("ship", 3);
                    else if (hit.collider.tag == "Ship04")
                        PlayerPrefs.SetInt("ship", 4);
                    else if (hit.collider.tag == "Ship05")
                        PlayerPrefs.SetInt("ship", 5);

                    PlayerPrefs.Save();
                    SceneManager.LoadScene("SampleScene");

                    timeElapsed = 0.0f;
                }
            }
        
        }
        else
            timeElapsed = 0.0f;

        Debug.Log(PlayerPrefs.GetInt("ship"));
    }
}
