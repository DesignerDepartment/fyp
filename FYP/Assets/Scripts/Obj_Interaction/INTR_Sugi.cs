using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTR_Sugi : MonoBehaviour
{
    public GameObject myHand;

    public GameObject handle;
    public GameObject sugi;
    public GameObject namaSugi;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        

    }



    //grabsabun
    public void grab()
    {

        handle.transform.forward = myHand.transform.forward;
        handle.transform.position = myHand.transform.position;
        //gayung.transform.position = handle.transform.position;


        handle.transform.SetParent(myHand.transform);
        
        //alwaysGrab();

    }

    public void showTextSugi()
    {

        namaSugi.SetActive(true);

    }

    public void unshowTextSugi()
    {

        namaSugi.SetActive(false);

    }

}
