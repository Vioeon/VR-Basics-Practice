using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpaceShip : MonoBehaviour
{

    public GameObject head;
    public GameObject mainCam;
    private GameObject ship;
    public GameObject spawnship;


    public GameObject ship1;
    public GameObject ship2;
    public GameObject ship3;
    public GameObject ship4;
    public GameObject ship5;

    float cur_angle;
    float prev_angle;
    float delta_angle;

    int PlayerNum;

    //public GameObject parent;
    private GameObject PlayerSelect;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.HasKey("ship"))
        {
            PlayerNum = PlayerPrefs.GetInt("ship");

            switch (PlayerNum)
            {
                case 1:
                    PlayerSelect = ship1;
                    break;
                case 2:
                    PlayerSelect = ship2;
                    break;
                case 3:
                    PlayerSelect = ship3;
                    break;
                case 4:
                    PlayerSelect = ship4;
                    break;
                case 5:
                    PlayerSelect = ship5;
                    break;
            }
        }

        //Vector3 pos = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y - 1.5f, mainCam.transform.position.z + 5f);
        //Vector3 pos = PlayerSelect.transform.position - mainCam.transform.position;
        Vector3 pos = spawnship.transform.position;
        Player = GameObject.Instantiate(PlayerSelect, pos, mainCam.transform.rotation);
        Player.transform.parent = mainCam.gameObject.transform;

        ship = Player;
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();

    }

    void MoveForward()
    {
        head.transform.Translate(mainCam.transform.forward * 0.3f);

        cur_angle = mainCam.transform.eulerAngles.y;
        delta_angle = cur_angle - prev_angle;
        prev_angle = cur_angle;

        if (delta_angle < 0)
        {
            ship.transform.rotation = Quaternion.Lerp(ship.transform.rotation,
                Quaternion.Euler(ship.transform.eulerAngles.x, ship.transform.eulerAngles.y, 45), Time.deltaTime);
        }
        else if (delta_angle > 0)
        {
            ship.transform.rotation = Quaternion.Lerp(ship.transform.rotation,
                Quaternion.Euler(ship.transform.eulerAngles.x, ship.transform.eulerAngles.y, -45), Time.deltaTime);
        }
        else
        {
            ship.transform.rotation = Quaternion.Lerp(ship.transform.rotation,
                Quaternion.Euler(ship.transform.eulerAngles.x, ship.transform.eulerAngles.y, 0), Time.deltaTime);
        }
    }
}
