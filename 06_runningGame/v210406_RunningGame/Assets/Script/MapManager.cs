using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Transform playerPosition;
    public GameObject[] maps = new GameObject[3];
    private int numSpawnedMap;

    private Queue<GameObject> mq;

    // Start is called before the first frame update
    void Start()
    {
        numSpawnedMap = 3;

        mq = new Queue<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPosition.position.z >= 50 * (numSpawnedMap - 2))
        {
            Vector3 nextSpawn = new Vector3(0, 0, 50 * numSpawnedMap);
            GameObject mobj = Instantiate(maps[Random.Range(0, 3)], nextSpawn, transform.rotation);
            numSpawnedMap++;

            mq.Enqueue(mobj);

            if(mq.Count > 3)
            {
                GameObject destryobj = mq.Dequeue();
                Destroy(destryobj);
            }

        }
        
    }
}
