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

    // Start is called before the first frame update
    void Start()
    {
        halo_on = false;
        maxHealth = startingHealth;
        currHealth = startingHealth;
        currMoney = startingMoney;
    }

    // Update is called once per frame
    void Update()
    {
        healthGUI.text = "Health: " + currHealth.ToString() + "/" + maxHealth.ToString() + "\n" + "Money: $" + currMoney;
        if (currHealth < 1)
        {
            timerGUI.text = "You Lose";
            SceneManager.LoadScene("Lose");
        }
    }

    public void EndLevel()
    {
        timer += Time.deltaTime;


        if (timer > displayGui)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
