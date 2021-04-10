using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RayClick : MonoBehaviour
{
    public Image cursorGaugeImage;
    public GameObject mainCam;
    private float gaugeTimer = 0.0f;
    private float gazeTime = 2.0f;

    private float walkSpeed = 5.0f;
    private bool isMoving = false;
    private Vector3 goalPosition;

    string goalobj = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = mainCam.transform.TransformDirection(Vector3.forward) * 1000;
        Debug.DrawRay(this.transform.position, forward, Color.green);
        cursorGaugeImage.fillAmount = gaugeTimer;


        if (Physics.Raycast(this.transform.position, forward, out hit))
        {
            if (hit.collider.tag != "Plane" && hit.collider.tag != "Wall" )
            {
                if (hit.collider.name != goalobj)
                {
                    gaugeTimer += 1.0f / gazeTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        Debug.Log(hit.point);
                        gaugeTimer = 0.0f;

                        goalPosition = new Vector3(hit.point.x, this.transform.position.y, hit.point.z);
                        isMoving = true;

                        goalobj = hit.collider.name;

                        StartCoroutine(MoveForward());
                    }
                }
                else
                    gaugeTimer = 0.0f;
            }
            else
                gaugeTimer = 0.0f;
        }
        else
            gaugeTimer = 0.0f;
    }

    IEnumerator MoveForward()
    {
        while (isMoving)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, goalPosition, Time.deltaTime * walkSpeed);
            
            gaugeTimer = 0.0f;
            if(this.transform.position.x == goalPosition.x && this.transform.position.z == goalPosition.z)
            {
                isMoving = false;
            }
            yield return null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == goalobj)
        {
            isMoving = false;
        }
    }

}
