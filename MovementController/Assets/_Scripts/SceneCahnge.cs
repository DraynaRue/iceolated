using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCahnge : MonoBehaviour
{

    public float timeElapsed;
    
    void Start()
    {

    }
    void Update ()
    {

        timeElapsed -= Time.deltaTime;

		if(timeElapsed <= 0)
		{
            SceneManager.LoadScene("MainMenu");
        }
     }
}


