using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInteraction : MonoBehaviour

{

    //public void PlayGame()
    //{
        //SceneManager.LoadScene(SceneManager.GetActiveScene().build + 1);
    //}

    // Update is called once per frame
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}