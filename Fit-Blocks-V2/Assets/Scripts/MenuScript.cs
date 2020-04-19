using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void MainManu()
    {
     
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //this will return us back into the main menu
        
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //this in theory will restart the scene it is basically a restart button 
    }
}
