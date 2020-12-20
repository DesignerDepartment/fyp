using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTR_SabunCon : MonoBehaviour
{
    public GameObject myHand;


    public GameObject sabun;
    public GameObject namaSabun;
    public GameObject handle;

    //release
    public GameObject tempatSabun;
    public GameObject pointerTempatSabun;

    // Start is called before the first frame update
    void Start()
    {

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


        handle.transform.SetParent(myHand.transform);
        unshowArrow();

        //alwaysGrab();

    }

    public Transform playerCam;
    public float throwForce = 10;

    public void release()
    {
        //sabun.transform.forward = pointerTempatSabun.transform.forward;
        //sabun.transform.position = pointerTempatSabun.transform.position;
        //sabun.transform.SetParent(pointerTempatSabun.transform);

        GetComponent<Rigidbody>().isKinematic = false;
        sabun.transform.SetParent(null);
        GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);

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
