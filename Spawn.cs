using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    public GameObject Player;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
           if (Player == null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    
            }
           else if (Player != null)
            {
                Player.transform.position = transform.position;
            }
        }


    }
}
