using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTR_Kapas : MonoBehaviour
{

    public GameObject namaKapas;

    public GameObject myHand;

    public GameObject kapas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void grab()
    {
        kapas.transform.SetParent(myHand.transform);
        kapas.transform.localPosition = myHand.transform.localPosition;


        //alwaysGrab();

    }


    public void showNamaKapas()
    {

        namaKapas.SetActive(true);

    }

    public void unshowNamaKapas()
    {

        namaKapas.SetActive(false);

    }
}
