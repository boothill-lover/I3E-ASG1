using UnityEngine;
using System.Collections;

public class stinkyCube : MonoBehaviour
{
    // let one running at one time, not alot of coroutines
    private bool damaging = false;
    
    // when i die
    public Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        // if player is touching the stinky cube
        if (other.CompareTag("Player") && !damaging)
        {
            // get player hp and start damaging
            StartCoroutine(DamagePlayer(other.GetComponent<PlayerHealth>()));
        }
    }

    IEnumerator DamagePlayer(PlayerHealth playerHealth)
    {
        for (int i = 0; i < 5; i++)
        {
            damaging = true;

            // 5 dmg every second for 5 times
            playerHealth.TakeDamage(5);

            yield return new WaitForSeconds(1f);
        }


        // allow damage again.
        damaging = false;
    }
}