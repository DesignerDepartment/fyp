using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trueButton : MonoBehaviour
{
    public Material[] material;
    Renderer rend;

    public GameObject yellow;

    int score = 0;
    public Text markah;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        yellow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //textScore();
    }

    public void toGreen() {
        rend.sharedMaterial = material[1];
    }

    public void toRed()
    {
        rend.sharedMaterial = material[3];
    }

    public void plusScore()
    {
        score = score + 1;
    }

    public void textScore()
    {
        markah.text = "" + score;
    }

    public void yellowOn()
    {
        yellow.SetActive(true);
    }

    public void yellowOff()
    {
        yellow.SetActive(false);
    }

}
