using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTR_SarungTangan : MonoBehaviour
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
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject circleAngkat;
    public GameObject Pointer;
    public GameObject ArrowAngkat;
    public GameObject ArrowIndicatorGlove;
    //public GameObject gayungIndicator;

    public GameObject indicatorInfoGayungGlove;
    public GameObject indicatorInfoGayungGlove2;

    public GameObject arrowMerahKakiKanan;
    public GameObject arrowMerahKakiKiri;
    public GameObject arrowMerahTanganKanan;
    public GameObject arrowMerahTanganKiri;
    public GameObject arrowMerahKepala;
    public GameObject infoGayungGlove;
    public GameObject arrowGlove;


    public void grab()
    {
        //glove.transform.SetParent(myHand.transform);
        // glove.transform.localPosition = myHand.transform.localPosition;
        //changeToGloveright();
        //changeToGloveLeft();
        //rend.sharedMaterial = material[1];
        Glove.SetActive(false);
        ArrowIndicatorGlove.SetActive(false);
        indicatorInfoGayungGlove2.SetActive(false);

        //alwaysGrab();
        //gayungIndicator.SetActive(true);
        if (ArrowIndicatorGlove.activeSelf == false)
        {
            ArrowAngkat.SetActive(true);
            circleAngkat.SetActive(true);
            Pointer.SetActive(true);
        }

       

    }

    public void showNamaGlove() {

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
