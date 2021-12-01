using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    // These methods connects to the buttons in the game, this is so that the player and leave or start the game as well as add a title and end screen

    // This method tells the program to quit when its pressed 
    public void ExitGame ()
    {
        Application.Quit();
    }

    // This method tells the program to move on to the next scene when pressed
    public void StartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
