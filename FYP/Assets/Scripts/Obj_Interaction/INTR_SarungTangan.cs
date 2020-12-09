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

    public void grab()
    {
        glove.transform.SetParent(myHand.transform);
        glove.transform.localPosition = myHand.transform.localPosition;


        //alwaysGrab();

    }

    public void showNamaGlove() {

        namaGlove.SetActive(true);

    }

    public void unshowNamaGlove()
    {

        namaGlove.SetActive(false);

    }

}
