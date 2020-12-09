using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBody : MonoBehaviour
{
    Animator player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cedok()
    {


        player.SetTrigger("air");
        Debug.Log("tunduk");

    }
}
