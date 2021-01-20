using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGlove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform playerCam;
    public float throwForce = 10;

    public void release() {

        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);

    }

    public void release2()
    {

        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);

    }

}
