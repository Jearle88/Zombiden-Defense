using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string scenename;

    public void OpenScene()
    {
        SceneManager.LoadScene(scenename);
    }
}
