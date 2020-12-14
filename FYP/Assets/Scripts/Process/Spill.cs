using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spill : MonoBehaviour
{
    ParticleSystem myWater;
    public GameObject water;

    // Start is called before the first frame update
    void Start()
    {
        myWater = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Angle(Vector3.down, transform.forward) <= 90f)
        {
            myWater.Play();
        }
        else {
            myWater.Stop();
        }
        
    }

    public void spill() {
        myWater.Play();
    }

    public void Stopspill()
    {
        myWater.Stop();
    }

    public void showSpill() {

        water.SetActive(true);
    
    }

}
