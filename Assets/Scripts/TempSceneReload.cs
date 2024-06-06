using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempSceneReset : MonoBehaviour
{
    // Update is called once per frame
    // this was a temporary scene reloader and is not really needed, but is nice not to have to press p to restart every time
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
