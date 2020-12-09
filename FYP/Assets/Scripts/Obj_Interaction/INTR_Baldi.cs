using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTR_Baldi : MonoBehaviour
{
    public GameObject baldi;
    public GameObject namaAir;
    //public AnimationTangan cedok;

    //Animator player;

    // Start is called before the first frame update
    void Start()
    {
      //  player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void showTextAir()
    {
        namaAir.SetActive(true);
    }

    public void unshowTextAir()
    {
        namaAir.SetActive(false);
    }

    public void showAirFull()
    {
        namaAir.SetActive(false);
    }

    public void showAirHalf()
    {
        namaAir.SetActive(false);
    }

    public void showAirQuater()
    {
        namaAir.SetActive(false);
    }

    public void unshowAirFull()
    {
        namaAir.SetActive(false);
    }

    public void unshowAirHalf()
    {
        namaAir.SetActive(false);
    }

    public void unshowAirQuater()
    {
        namaAir.SetActive(false);
    }



}
 