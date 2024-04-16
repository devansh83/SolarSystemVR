using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                //change scene from loaded to Skybox if current scene is SolarSystemWithPlanets_Divit
                if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "SolarSystemWithPlanets_Divit")
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Earth");
                }
                else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Earth")
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Mars");
                }
                else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Mars")
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("SolarSystemWithPlanets_Divit");
                }
                // else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Jupiter")
                // {
                //     UnityEngine.SceneManagement.SceneManager.LoadScene("Saturn");
                // }
                // else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Saturn")
                // {
                //     UnityEngine.SceneManagement.SceneManager.LoadScene("Uranus");
                // }
                // else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Uranus")
                // {
                //     UnityEngine.SceneManagement.SceneManager.LoadScene("Neptune");
                // }
                // else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Neptune")
                // {
                //     UnityEngine.SceneManagement.SceneManager.LoadScene("Pluto");
                // }
                // else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Pluto")
                // {
                //     UnityEngine.SceneManagement.SceneManager.LoadScene("SolarSystemWithPlanets_Divit");
                // }
            }
        }
    }
}
