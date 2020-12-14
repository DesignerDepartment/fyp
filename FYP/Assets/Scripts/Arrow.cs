using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject arrowRedTanganKiri;
    public GameObject arrowGreenTanganKiri;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showRed() {

        arrowRedTanganKiri.SetActive(true);

    }

    public void showGreen()
    {

        arrowGreenTanganKiri.SetActive(true);

    }

    public void unshowRed()
    {

        arrowRedTanganKiri.SetActive(false);

    }

    public void unshowGreen()
    {

        arrowGreenTanganKiri.SetActive(false);

    }



}
