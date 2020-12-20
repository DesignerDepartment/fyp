using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTanganKanan : MonoBehaviour
{
    public Transform gayung;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("gayung"))
        {
            UnityEngine.Debug.Log("Curahhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
        }
    }
    */

    public void arrowDetect()
    {
        if (Vector3.Distance(transform.position, gayung.position) <= 1)
        {
            UnityEngine.Debug.Log("Arrow hilang ");
            arrow.SetActive(false);
        }
    }
}
