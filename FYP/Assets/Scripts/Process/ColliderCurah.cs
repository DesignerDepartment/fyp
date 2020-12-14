using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCurah : MonoBehaviour
{
    //[SerializeField] private Animator curah;

    public GameObject ArrowRedTanganKiriCollider;
    public GameObject ArrowGreenTanganKiriCollider;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTrigger(Collider other)
    {
        if (other.CompareTag("Air"))
        {
            ArrowRedTanganKiriCollider.SetActive(false);
        }
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Air"))
        {

            curah.SetBool("curah", false);

        }
    }
    */

   
}
