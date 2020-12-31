using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTR_Tuala : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        tuala.SetActive(false);
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


    public void grab()
    {
        //StartCoroutine(timetakenGrabTuala());
        tuala2.SetActive(false);
        tuala.SetActive(true);
    }

}
