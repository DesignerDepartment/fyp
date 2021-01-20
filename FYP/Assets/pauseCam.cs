using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseCam : MonoBehaviour
{

    Camera cam;
    public CamMouseLook look;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        look = GetComponent<CamMouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (menu.activeSelf == true)
        {
            
            cam.enabled = false;
            look.enabled = false;
        }
        else {

            
            cam.enabled = true;
            look.enabled = true;
        }
    }
}
