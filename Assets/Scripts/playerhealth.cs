using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerhealth : MonoBehaviour
{
    public float Health;
    private float maxHealth;
    public TextMeshProUGUI healthGUI;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {
        healthGUI.text = "Health: " + Health.ToString() + "/" + maxHealth.ToString();
    }
}
