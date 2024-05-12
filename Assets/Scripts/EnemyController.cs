using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemy;
    public int health = 5;
    public float MoneyDealt = 10;

    public void Damage(int damage)
    {
        health -= damage;
    }   

    private void Update()
    {
        if (health <= 0)
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<playerdata>().currMoney += MoneyDealt;
            enemy.SetActive(false);
        }
    }

}
