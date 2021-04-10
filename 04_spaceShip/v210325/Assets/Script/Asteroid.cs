using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject explosion;
    public AudioClip explosionSound;

    private void OnTriggerEnter(Collider other)
    {
        
        StartCoroutine(Crash());
    }

    IEnumerator Crash()
    {
        GameObject ast = gameObject.transform.Find("test_asteroid").gameObject;

        ast.SetActive(false);
            
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(explosionSound);
        explosion.SetActive(true);
        
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject); 
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
