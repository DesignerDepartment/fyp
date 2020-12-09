using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    int score = 0;
    public Text markah;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textScore();
    }


    public void plusScore() {

        score = score + 1;
    
    }

    public void textScore() {

        markah.text = ""+score;

    }

}
