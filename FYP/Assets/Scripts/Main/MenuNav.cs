using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuNav : MonoBehaviour
{
    [SerializeField] private Animator info;
    public GameObject buttonOpen;
    public GameObject buttonClose;
    public GameObject menu;

    void Start()
    {
        buttonClose.SetActive(false);
        
        menu.SetActive(true);
    }

    public void FYP_Scene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit() {
        Application.Quit();
    }

    IEnumerator idleTimer()
    {
        //Print the time of when the function is first called.
        UnityEngine.Debug.Log("close");
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        info.SetBool("idle", true);
        info.SetBool("close", false);
        //After we have waited 5 seconds print the time again.
        UnityEngine.Debug.Log("idle state");
    }

    public void showInfo() {

        //info.SetBool("open", true);
        //info.SetBool("idle", false);
        buttonClose.SetActive(true);
        buttonOpen.SetActive(false);
        menu.SetActive(false);
    }

    public void closeInfo()
    {
        //info.SetBool("close", true);
        //info.SetBool("open", false);
        //StartCoroutine(idleTimer());
        buttonClose.SetActive(false);
        buttonOpen.SetActive(true);
        menu.SetActive(true);
        menu.SetActive(true);
    }


}
 