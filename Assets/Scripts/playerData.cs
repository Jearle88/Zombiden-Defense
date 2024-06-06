using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class playerdata : MonoBehaviour
{
    public float startingHealth;
    public float startingMoney;
    [System.NonSerialized]
    public float currHealth;
    [System.NonSerialized]
    public float currMoney;
    private float maxHealth;
    private float displayGui = 5f;
    private float timer;
    public TextMeshProUGUI healthGUI;
    public TextMeshProUGUI timerGUI;
    [System.NonSerialized] public bool halo_on;
    public GameObject PauseMenu;

    // Start is called before the first frame update
    // Makes sure the game functions after a scene reset and that our stuff is initialized
    void Start()
    {
        Time.timeScale = 1.0f; 
        halo_on = false;
        maxHealth = startingHealth;
        currHealth = startingHealth;
        currMoney = startingMoney;
    }

    // Update is called once per frame
    void Update()
    {
        // gives our player information
        healthGUI.text = "Health: " + currHealth.ToString() + "/" + maxHealth.ToString() + "\n" + "Money: $" + currMoney;
        // checks if the game should be paused/unpaused
        if(Input.GetKeyDown("p"))
        {
            if(PauseMenu.activeSelf == false)
            {
                Time.timeScale = 0.0f;
                PauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1.0f;
                PauseMenu.SetActive(false);
            }
        }
        if (currHealth < 1)
        {
            timerGUI.text = "You Lose";
            SceneManager.LoadScene("Lose");
        }
    }

    // old EndLevel function, do not think this is still used
    public void EndLevel()
    {
        timer += Time.deltaTime;


        if (timer > displayGui)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
