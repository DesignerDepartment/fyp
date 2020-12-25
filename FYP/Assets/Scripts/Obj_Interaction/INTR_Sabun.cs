using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTR_Sabun : MonoBehaviour
{
    public GameObject myHand;


    public GameObject sabun;
    public GameObject namaSabun;
    public GameObject handle;
    public GameObject sabunIndicator;
    public GameObject arrowProcessSabun;

    //release
    public GameObject tempatSabun;
    public GameObject pointerTempatSabun;

    public GameObject gayungBilasSabun;
    public GameObject gayungBasuhanPertama;

    public GameObject arrowSabunkanJenazah;

    // Start is called before the first frame update
    void Start()
    {
        arrowProcessSabun.SetActive(false);
        arrowSabunkanJenazah.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {

       

    }



    //grabgayung
    public void grab()
    {
        

        handle.transform.forward = myHand.transform.forward;
        handle.transform.position = myHand.transform.position;

        GetComponent<Rigidbody>().isKinematic = true;
        handle.transform.SetParent(myHand.transform);
        unshowArrow();
        sabunIndicator.SetActive(false);

        arrowProcessSabun.SetActive(true);

        //GetComponent<Rigidbody>().isKinematic = true;

        //alwaysGrab();

        arrowSabunkanJenazah.SetActive(true);

    }

    public Transform playerCam;
    public float throwForce = 10;

    public void release()
    {
        //handle.transform.forward = pointerTempatSabun.transform.forward;
        //handle.transform.position = pointerTempatSabun.transform.position;
        //handle.transform.SetParent(pointerTempatSabun.transform);

        GetComponent<Rigidbody>().isKinematic = false;
        handle.transform.SetParent(null);
        GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);

        gayungBilasSabun.SetActive(true);
        gayungBasuhanPertama.SetActive(false);

        arrowProcessSabun.SetActive(false);

        arrowSabunkanJenazah.SetActive(false);
    }


    public void showText()
    {

        namaSabun.SetActive(true);

    }

    public void unshowText()
    {

        namaSabun.SetActive(false);

    }

    public GameObject arrowSabun;

    public void unshowArrow()
    {

        arrowSabun.SetActive(false);

    }

    
}
