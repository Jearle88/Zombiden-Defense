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
    public TextMeshProUGUI healthGUI;
    public TextMeshProUGUI timerGUI;

    // Start is called before the first frame update
    void Start()
    {
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
