using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadObject : MonoBehaviour
{

    public INTR_Gayung gayung;
    public INTR_Sabun sabun;
    public INTR_Sugi sugi;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void releaseGayung() {

        if (gayung != null)
        {
            gayung.release();
        }
    }

    public void releaseSabun()
    {

        if (sabun != null)
        {
            sabun.release();
        }
    }

    public void releaseSugi()
    {

        if (sabun != null)
        {
            sabun.release();
        }
    }

}
