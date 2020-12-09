using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTangan : MonoBehaviour
{

    Animator player;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void pegangGayung() {
        

            player.SetTrigger("Grabbed");
            Debug.Log("grabGayung");

    }

    public void pegangSabun()
    {


        player.SetTrigger("GrabSabun");
        Debug.Log("grabSabun");

    }

    public void pegangSugi()
    {


        player.SetTrigger("GrabSugi");
        Debug.Log("grabSugi");

    }

    public void idle()
    {


        player.SetTrigger("idle");
        Debug.Log("idle");

    }

    public void cedok()
    {


        player.SetTrigger("ambilAir");
        Debug.Log("cedok");
    }

    public void stopCedok()
    {
        player.ResetTrigger("ambilAir");
        Debug.Log("Stop cedok");
    }

    public void pointerCedok()
    {


        player.SetTrigger("pointerCedok");
        Debug.Log("pointer");

    }

    public void stopTunduk()
    {

        player.enabled = false;

    }








}
