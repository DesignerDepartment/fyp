using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject arrowRed;
    public GameObject arrowGreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showRed() {

        arrowRed.SetActive(true);

    }

    public void showGreen()
    {

        arrowGreen.SetActive(true);

    }

    public void unshowRed()
    {

        arrowRed.SetActive(false);

    }

    public void unshowGreen()
    {

        arrowGreen.SetActive(false);

    }
}
