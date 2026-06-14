using UnityEngine;
using System.Collections;

/*
* Author: Carolyn
* Date: 12/07/26
* Description: Script for my mushroom soup hazard that deals damage when you fall in it
*/

public class MushroomSoup : MonoBehaviour
{
    // whether you are inside the soup, and whether you can start taking dmg
    private bool isInside = false;
    private bool canDamage = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // if inside, start coroutine
            isInside = true;
            StartCoroutine(DamageLoop(other.GetComponent<PlayerHealth>()));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // no longer inside
            isInside = false;
        }
    }

    IEnumerator DamageLoop(PlayerHealth playerHealth)
    {
        while (isInside)
        {
            if (playerHealth != null && canDamage)
            {
                canDamage = false;

                // damage every 1 second
                playerHealth.TakeDamage(5);

                yield return new WaitForSeconds(1f);

                canDamage = true;
            }

            yield return null;
        }
    }
}