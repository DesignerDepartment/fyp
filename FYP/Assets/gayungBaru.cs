﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gayungBaru : MonoBehaviour
{
    //grab
    public GameObject myHand;
    public GameObject handle2;
    public GameObject gayung2;
    public GameObject namaGayung2;
    public GameObject air;

    public GameObject arrowAmbilAirBilasAirSabun;

    public GameObject arrowGayung2;

    public GameObject arrowCedokBilasSabun;

    //release



    // Start is called before the first frame update
    void Start()
    {
        unshowAir();
        unshowArrowAmbilAir();

        arrowAmbilAirBilasAirSabun.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {



    }



    //grabgayung
    public void grab()
    {
        //gayung.transform.SetParent(handle.transform);
        handle2.transform.position = myHand.transform.position;
        handle2.transform.forward = myHand.transform.forward;

        arrowAmbilAirBilasAirSabun.SetActive(true);

        GetComponent<Rigidbody>().isKinematic = true;

        handle2.transform.SetParent(myHand.transform);

        unshowArrow();

        showArrowAmbilAir();

        //air.SetActive(true);

        arrowGayung2.SetActive(false);

        arrowCedokBilasSabun.SetActive(true);

        



    }

    public Transform playerCam;
    public float throwForce = 10;


    public void release()
    {
            GetComponent<Rigidbody>().isKinematic = false;
            handle2.transform.SetParent(null);
            GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);

            air.SetActive(false);

    }

    public void showTextGayung()
    {

        namaGayung2.SetActive(true);

    }

    public void unshowTextGayung()
    {

        namaGayung2.SetActive(false);

    }

    public void showAir()
    {
        air.SetActive(true);
    }

    public void unshowAir()
    {
        air.SetActive(false);
    }

    public GameObject arrowGayung;

    public void unshowArrow()
    {

        arrowGayung.SetActive(false);

    }

    public GameObject arrowAmbilAir;

    public void showArrowAmbilAir()
    {

        arrowAmbilAir.SetActive(true);

    }

    public void unshowArrowAmbilAir()
    {

        arrowAmbilAir.SetActive(false);

    }
}
