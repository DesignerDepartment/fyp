using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextButton : MonoBehaviour
{

    public GameObject green;

    // Start is called before the first frame update
    void Start()
    {
        green.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void greenOn() {

        green.SetActive(true);

    }

    public void greenOff()
    {

        green.SetActive(false);

    }

}
