using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTR_Tuala : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        tuala.SetActive(false);
        triggerLap.SetActive(false);
        arrowKeringkanJenazah.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator timetakenGrabTuala()
    {
        //Print the time of when the function is first called.
        UnityEngine.Debug.Log("Start grb tuala");
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        tuala.SetActive(true);
        //After we have waited 5 seconds print the time again.
        UnityEngine.Debug.Log("done grb");
    }

    public GameObject tuala;
    public GameObject tuala2;
    public GameObject arrowLapJenazah;
    public GameObject triggerLap;
    public GameObject arrowKeringkanJenazah;
    public GameObject arrowWudhuJenazah;
    public GameObject arrowWudhukanJenazah;
    public GameObject indicatorWudhu;
    public GameObject arrowAmbilTuala;

    public void grab()
    {
        //StartCoroutine(timetakenGrabTuala());
        if (arrowAmbilTuala.activeSelf == true)
        {
            tuala2.SetActive(false);
            tuala.SetActive(true);
            arrowLapJenazah.SetActive(true);
            triggerLap.SetActive(true);
            arrowKeringkanJenazah.SetActive(true);
            arrowWudhuJenazah.SetActive(false);
            arrowWudhukanJenazah.SetActive(false);
            indicatorWudhu.SetActive(false);
        }
        else {

            UnityEngine.Debug.Log("Ikut arahan anak panah");

        }
        
    }

}
