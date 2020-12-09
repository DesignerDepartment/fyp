using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabGayung : MonoBehaviour
{

    public GameObject gayung;
    public GameObject myHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            gayung.transform.SetParent(myHand.transform);
            gayung.transform.localPosition = myHand.transform.localPosition; 
        }
    } 





}
