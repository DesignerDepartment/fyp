using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTR_Tuala2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject namaTuala;

    public void showNamaTuala()
    {

        namaTuala.SetActive(true);

    }

    public void unshowNamaTuala()
    {

        namaTuala.SetActive(false);

    }

}
