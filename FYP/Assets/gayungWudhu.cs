using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gayungWudhu : MonoBehaviour
{
    //grab
    public GameObject myHand;
    public GameObject handle3;
    public GameObject gayung3;
    public GameObject namaGayung3;
    public GameObject air;

    public GameObject arrowAmbilAirWudhu;

    public GameObject arrowGayung3;

    public GameObject arrowCedokBilasSabun;

    //release



    // Start is called before the first frame update
    void Start()
    {
        unshowAir();
        unshowArrowAmbilAir();

        arrowAmbilAirWudhu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {



    }



    //grabgayung
    public void grab()
    {
        //gayung.transform.SetParent(handle.transform);
        handle3.transform.position = myHand.transform.position;
        handle3.transform.forward = myHand.transform.forward;
        arrowAmbilAirWudhu.SetActive(true);

        GetComponent<Rigidbody>().isKinematic = true;
        handle3.transform.SetParent(myHand.transform);

        unshowArrow();
        showArrowAmbilAir();

        arrowGayung3.SetActive(false);
        arrowCedokBilasSabun.SetActive(false);



    }

    public Transform playerCam;
    public float throwForce = 10;



    IEnumerator unnotiGayung()
    {
        //Print the time of when the function is first called.
        UnityEngine.Debug.Log("Start noti gayung");
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(6);
        //notiGayung.SetActive(false);
        //After we have waited 5 seconds print the time again.
        UnityEngine.Debug.Log("Start noti gayung");
    }



    public void release()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        handle3.transform.SetParent(null);
        GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);

        air.SetActive(false);

    }

    public void showTextGayung()
    {

        namaGayung3.SetActive(true);

    }

    public void unshowTextGayung()
    {

        namaGayung3.SetActive(false);

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
