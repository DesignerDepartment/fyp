using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTR_SarungTangan2 : MonoBehaviour
{
    public GameObject namaGlove;

    public GameObject myHand;

    public GameObject glove;



    //public Material[] material;
    //Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        //rend = GetComponent<Renderer>();
        // rend.enabled = true;
        //rend.sharedMaterial = material[0];

        //ArrowAmbilGlove.SetActive(false);
        //Glove.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public GameObject gayungIndicator;

    
    public GameObject arrowGlove;
    public GameObject Glove2;

    public GameObject ArrowAmbilGlove;

    public GameObject arrowSabun;

    public void grab()
    {
        Glove.SetActive(false);

        ArrowAmbilGlove.SetActive(false);

        arrowSabun.SetActive(true);
    }

    public void showNamaGlove()
    {

        namaGlove.SetActive(true);

    }

    public void unshowNamaGlove()
    {

        namaGlove.SetActive(false);

    }

    // public GameObject gloveKanan;
    //public GameObject gloveKiri;
    public GameObject Kiri;
    public GameObject Kanan;
    public GameObject Glove;

    public void changeToGloveright()
    {
        //tukar material



        // gloveKanan.SetActive(true);
        // Kanan.SetActive(false);
    }

    public void changeToGloveLeft()
    {
        //tukar material
        // gloveKiri.SetActive(true);
        // Kiri.SetActive(false);
    }

    public void throwGlove()
    {
        // gloveKanan.SetActive(false);
        // gloveKiri.SetActive(false);
    }

}
