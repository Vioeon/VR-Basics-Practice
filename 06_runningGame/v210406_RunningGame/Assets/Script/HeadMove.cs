using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeadMove : MonoBehaviour
{
    public GameObject mainCam;
    private float moveSpeed = 10.0f;
    private float runSpeed = 10.0f;
    private float positionX = 0.0f;
    private float accel = 0.5f;

    public Text timeText;
    private float time;

    bool crash = false;

    public Text count;
    private float timer = 3f;

    public Text end;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpeedUp());
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            count.text = Mathf.Ceil(timer).ToString();

            timer -= Time.deltaTime;
        }
        
        
        if (timer <= 0)
        {
            count.gameObject.SetActive(false);

            positionX = this.transform.position.x - mainCam.transform.rotation.z * moveSpeed / 90.0f;

            this.transform.position = new Vector3(positionX, this.transform.position.y, this.transform.position.z);

            Run();

            if (!crash)
            {
                time += Time.deltaTime;
                timeText.text = string.Format("{0:N2}", time);
            }
        }
    }

    void Run()
    {
        this.transform.position += this.transform.forward * runSpeed * Time.deltaTime;
    }

    IEnumerator SpeedUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);

            if(runSpeed < 13 && runSpeed != 0)
                runSpeed += accel;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Obstacle")
        {
            crash = true;

            runSpeed = 0;

            end.gameObject.SetActive(true);

            StartCoroutine(Restart());
        }

    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("SampleScene");
    }
}
