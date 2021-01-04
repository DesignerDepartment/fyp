using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToGlove : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    public GameObject arrowAmbilGlove;
    public GameObject glove;
    public GameObject gloveBuang;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (arrowAmbilGlove.activeSelf == false && glove.activeSelf == false && gloveBuang.activeSelf == false)
        {
            rend.sharedMaterial = material[1];
        }
        else {

            rend.sharedMaterial = material[0];

        }
        
    }

   
}
