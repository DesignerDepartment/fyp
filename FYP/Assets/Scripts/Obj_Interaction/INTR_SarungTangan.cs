using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTR_SarungTangan : MonoBehaviour
{
    public GameObject namaGlove;

    public GameObject myHand;
    
    public GameObject glove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject circleAngkat;
    public GameObject Pointer;
    public GameObject ArrowAngkat;
    public GameObject ArrowIndicatorGlove;

    public void grab()
    {
        //glove.transform.SetParent(myHand.transform);
        // glove.transform.localPosition = myHand.transform.localPosition;
        changeToGloveright();
        changeToGloveLeft();
        Glove.SetActive(false);
        ArrowIndicatorGlove.SetActive(false);
        //alwaysGrab();

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

    public GameObject gloveKanan;
    public GameObject gloveKiri;
    public GameObject Kiri;
    public GameObject Kanan;
    public GameObject Glove;

    public void changeToGloveright()
    {

        gloveKanan.SetActive(true);
        Kanan.SetActive(false);
    }

    public void changeToGloveLeft()
    {

        gloveKiri.SetActive(true);
        Kiri.SetActive(false);
    }

    public void throwGlove()
    {

        gloveKanan.SetActive(false);
        gloveKiri.SetActive(false);

    }

}
