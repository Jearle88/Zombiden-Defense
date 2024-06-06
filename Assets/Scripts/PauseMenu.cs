using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string scenename;

    // this is used for the individual buttons on the pause screen
    public void OpenScene()
    {
        SceneManager.LoadScene(scenename);
    }
}
