using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTR_GayungCon : MonoBehaviour
{
    //grab
    public GameObject myHand;
    public GameObject handle;
    public GameObject gayung;
    public GameObject namaGayung;
    public GameObject air;
    public GameObject LangkahPertama;
    public GameObject LangkahKedua;

    //release
    public GameObject tempatGayung;


    // Start is called before the first frame update
    void Start()
    {
        unshowAir();
        unshowArrowAmbilAir();
        var cubeRenderer = LangkahPertama.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.green);

        Pointer.SetActive(false);

        ArrowAngkat.SetActive(false);

        ArrowGlove.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        ;
        if (arrowMerahTanganKanan.activeSelf == false && arrowMerahTanganKiri.activeSelf == false && arrowMerahKakiKanan.activeSelf == false && arrowMerahKakiKiri.activeSelf == false)
        {
            air.SetActive(false);
        }


    }



    //grabgayung
    public void grab()
    {
        //gayung.transform.SetParent(handle.transform);
        handle.transform.position = myHand.transform.position;
        handle.transform.forward = myHand.transform.forward;


        GetComponent<Rigidbody>().isKinematic = true;

        handle.transform.SetParent(myHand.transform);

        unshowArrow();

        showArrowAmbilAir();



    }


    public Transform playerCam;
    public float throwForce = 10;

    public GameObject arrowHijauTanganKiri;
    public GameObject arrowHijauTanganKanan;
    public GameObject arrowHijauKakiKanan;
    public GameObject arrowHijauKakiKiri;
    public GameObject arrowHijauKepala;

    public GameObject arrowHijau;

    public GameObject arrowMerahTanganKiri;
    public GameObject arrowMerahTanganKanan;
    public GameObject arrowMerahKakiKanan;
    public GameObject arrowMerahKakiKiri;
    public GameObject arrowMerahKepala;

    public GameObject indicatorArrowAngkat;


    public GameObject ArrowGlove;
    public GameObject ArrowIndicatorGlove;
    public GameObject circleAngkat;
    public GameObject Pointer;
    public GameObject ArrowAngkat;

    public GameObject errorSiram;

    public void release()
    {

        //handle.transform.SetParent(pointerTempatGayung.transform);
        //handle.transform.position = pointerTempatGayung.transform.position;
        //handle.transform.forward = pointerTempatGayung.transform.forward;

        //handle.transform.SetParent(empty.transform);
        //handle.transform.SetParent(null);

        if (arrowMerahTanganKanan.activeSelf == true && arrowMerahTanganKiri.activeSelf == true && arrowMerahKakiKanan.activeSelf == true && arrowMerahKakiKiri.activeSelf == true)
        {
            errorSiram.SetActive(true);
        }
        else
        {

            if (arrowMerahTanganKanan.activeSelf == false && arrowMerahTanganKiri.activeSelf == false && arrowMerahKakiKanan.activeSelf == false && arrowMerahKakiKiri.activeSelf == false)
            {
                arrowHijau.SetActive(false);
                indicatorArrowAngkat.SetActive(false);
            }

            if (arrowHijau.activeSelf == false && indicatorArrowAngkat.activeSelf == false)
            {

                ArrowGlove.SetActive(true);
                //
            }



            GetComponent<Rigidbody>().isKinematic = false;
            handle.transform.SetParent(null);
            GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);

            var d = LangkahPertama.GetComponent<Renderer>();
            d.material.SetColor("_Color", Color.grey);

            var dr = LangkahKedua.GetComponent<Renderer>();
            dr.material.SetColor("_Color", Color.green);

            air.SetActive(false);
        }



        //handle.transform.localPosition = new Vector3(6.747f, 2.429f, 10.524f);


    }

    public void showTextGayung()
    {

        namaGayung.SetActive(true);

    }

    public void unshowTextGayung()
    {

        namaGayung.SetActive(false);

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
