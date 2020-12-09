using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuNav : MonoBehaviour
{


    public void FYP_Scene() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Exit() {

        Application.Quit();

    }


}
 