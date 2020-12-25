using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterspill : MonoBehaviour
{
    ParticleSystem myWater;
    Animator particle;

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
        else
        {
            myWater.Stop();
        }

    }





}
