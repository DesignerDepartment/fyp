using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class q1Button : MonoBehaviour
{
    public GameObject green;

    public Material[] material;
    Renderer rend;

    public GameObject yellow;

    //int score = 0;
    public Text markah;

    // Start is called before the first frame update
    void Start()
    {
        green.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void greenOn()
    {

        green.SetActive(true);

    }

    public void greenOff()
    {

        green.SetActive(false);

    }
}
