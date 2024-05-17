using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{

    //Called when StartBTN Pressed
    public void StartGame()
    {
        //Load Game Scene
        SceneManager.LoadScene("Main");
    }
}
