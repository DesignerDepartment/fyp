using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTR_TongSampah : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject namaTongSampah;

    public void showNamaTongSampah()
    {

        namaTongSampah.SetActive(true);

    }

    public void unshowNamaTongSampah()
    {

        namaTongSampah.SetActive(false);

    }

}
