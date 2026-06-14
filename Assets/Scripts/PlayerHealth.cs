using UnityEngine;
using TMPro;
using System.Collections;
using StarterAssets;

/*
* Author: Carolyn
* Date: 12/07/26
* Description: Script for my health system,
*/

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private FirstPersonController player;

    // max hp
    public int health = 100;

    // for when i die
    public Transform respawnPoint;
    public GameObject deathScreen;
    public TMP_Text healthText;

    private bool isDead = false;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        UpdateUI();
        // i mean its already disabled by default but just in case
        deathScreen.SetActive(false);
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        health -= amount;

        if (health <= 0)
        {
            health = 0;
            StartCoroutine(Die());   
        }

        UpdateUI();
    }

    IEnumerator Die()
    {
        isDead = true;

        // death screen and disable movement
        deathScreen.SetActive(true);
        player.enabled = false;

        if (controller != null)
            controller.enabled = false;

        // 3 seconds then respawn
        yield return new WaitForSeconds(3f);

        // move player to the respawnpoint
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;

        // enable movement
        if (controller != null)
            controller.enabled = true;

        player.enabled = true;

        // back to full and remove death screen
        health = 100;
        UpdateUI();
        deathScreen.SetActive(false);

        // no longer dead
        isDead = false;
    }

    void UpdateUI()
    {
        healthText.text = "HP: " + health;
    }
}