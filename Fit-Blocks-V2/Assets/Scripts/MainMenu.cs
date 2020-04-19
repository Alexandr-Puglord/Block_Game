using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  //this will go from Menu 0 to GameScene 1 
                                                                               //The build will 
    }

    public void Exit()
    {
        Debug.Log("Exiting Game"); //this is a confirmation message that will popup in the unity engine 
        Application.Quit(); //this will in fact exit the program 
    }

}
