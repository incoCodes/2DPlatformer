using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
    // This tells the program that if the player presses the R key then restart the level, this is done by getting access to the scene manager in the program
    // and reactivating the current scene that the player is in.
    // I added this so that if the player dies from an enemy then they can restart which eliminates their inconvinences if they die. 
        if (Input.GetKeyDown(KeyCode.R))
        {
        
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                  
        }


    }
}
