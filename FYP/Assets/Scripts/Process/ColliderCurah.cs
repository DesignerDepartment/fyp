using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCurah : MonoBehaviour
{
    public GameObject detect;

    // Start is called before the first frame update
    void Start()
    {
        detect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("PLayer"))
        {
            detect.SetActive(true);
        }
    }

   
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PLayer"))
        {

            detect.SetActive(false);

        }
    }
    

   
}
