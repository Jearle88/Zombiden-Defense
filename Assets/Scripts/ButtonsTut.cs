using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsTut : MonoBehaviour
{
    public Text Textfield;
    public GameObject track;

    public void Next(string text)
    {
        track.GetComponent<tracker>().slide++;
        if (track.GetComponent<tracker>().slide == 0)
            Textfield.text = "WELCOME TO ZOMBIDEN TD! The aim of the game is to defend Biden from the zombies. Zombies spawn in waves, gaining more health and speed each time. Every fifth wave is a boss wave.";
        if (track.GetComponent<tracker>().slide == 1)
            Textfield.text = "Place towers by dragging and dropping them. Each tower is unique, doing different amounts of damage, having different reload times, and with different ranges. The legendary tower attacks everything in range!";
        if (track.GetComponent<tracker>().slide == 2)
            Textfield.text = "You can move the camera with WASD! You can press \"p\" to pause and press \"h\" to show tower rangers. That's about it, have fun!";
        if (track.GetComponent<tracker>().slide == 3)
            Textfield.text = "";
    }

    public void Prev(string text)
    {
        track.GetComponent<tracker>().slide--;
        if (track.GetComponent<tracker>().slide == 0)
            Textfield.text = "WELCOME TO ZOMBIDEN TD! The aim of the game is to defend Biden from the zombies. Zombies spawn in waves, gaining more health and speed each time. Every fifth wave is a boss wave.";
        if (track.GetComponent<tracker>().slide == 1)
            Textfield.text = "Place towers by dragging and dropping them. Each tower is unique, doing different amounts of damage, having different reload times, and with different ranges. The legendary tower attacks everything in range!";
        if (track.GetComponent<tracker>().slide == 2)
            Textfield.text = "You can move the camera with WASD! You can press \"p\" to pause and press \"h\" to show tower rangers. That's about it, have fun!";
        if (track.GetComponent<tracker>().slide == 3)
            Textfield.text = "";
    }

    public void Close(string text)
    {
        if (track.GetComponent<tracker>().slide == 3){
            track.GetComponent<tracker>().slide = 0;
            Textfield.text = "WELCOME TO ZOMBIDEN TD! The aim of the game is to defend Biden from the zombies. Zombies spawn in waves, gaining more health and speed each time. Every fifth wave is a boss wave.";
        }
        else {
        track.GetComponent<tracker>().slide = 3;
        Textfield.text = "";
        }
        
    }

}
