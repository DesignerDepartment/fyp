using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTR_Corpse : MonoBehaviour
{
    public GameObject LenganKiri;
    public GameObject buttonE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showButtonE()
    {
        buttonE.SetActive(true);
    }

    public void unshowButtonE()
    {
        buttonE.SetActive(false);
    }



}
