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

    public GameObject arrowAmbilGlove2;
    public GameObject glove2;
    public GameObject gloveBuang2;

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
        if (arrowAmbilGlove.activeSelf == false && glove.activeSelf == false && gloveBuang.activeSelf == false || arrowAmbilGlove2.activeSelf == false && glove2.activeSelf == false && gloveBuang2.activeSelf == false)
        {
            rend.sharedMaterial = material[1];
        }
        else
        {
            rend.sharedMaterial = material[0];
        }
    }

    public void toGlove() {
        rend.sharedMaterial = material[1];
    }

    public void toHand()
    {
        rend.sharedMaterial = material[0];
    }

}
