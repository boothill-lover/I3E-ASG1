using UnityEngine;
using TMPro;

/*
* Author: Carolyn
* Date: 12/07/26
* Description: Script for my health system,
*/

public class PlayerHealth : MonoBehaviour
{
    // max hp
    public int health = 100;

    public Transform respawnPoint;

    public TMP_Text healthText;

    private void Start()
    {
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health < 0)
            health = 0;

        UpdateUI();
    }

    void UpdateUI()
    {
        healthText.text = "HP: " + health;
    }
}