using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTR_Gayung : MonoBehaviour
{
    //grab
    public GameObject myHand;
    public GameObject gayung;
    public GameObject handle;
    public GameObject namaGayung;
    public GameObject air;
    public GameObject LangkahPertama;
    public GameObject LangkahKedua;

    //release
    public GameObject tempatGayung;
    public GameObject pointerTempatGayung;



    // Start is called before the first frame update
    void Start()
    {
        unshowAir();

        var cubeRenderer = LangkahPertama.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.green);
    }

    // Update is called once per frame
    void Update()
    {

        //alwaysGrab();

    }



    //grabgayung
    public void grab()
    {
         
        handle.transform.forward = myHand.transform.forward;
        handle.transform.position = myHand.transform.position;
        

        handle.transform.SetParent(myHand.transform);

        var d = LangkahPertama.GetComponent<Renderer>();
        d.material.SetColor("_Color", Color.grey);

        var dr = LangkahKedua.GetComponent<Renderer>();
        dr.material.SetColor("_Color", Color.green);

    }



    public void release() {

        gayung.transform.forward = pointerTempatGayung.transform.forward;
        gayung.transform.position = pointerTempatGayung.transform.position;
        gayung.transform.SetParent(pointerTempatGayung.transform);
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
}
