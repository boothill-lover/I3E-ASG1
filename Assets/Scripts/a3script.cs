using UnityEngine;

/*
* Author: Carolyn
* Date: 14/07/26
* Description: Script for the trigger zone to identify that this is Area 3, and set it as such for my UI to update.
*/


public class a3script : MonoBehaviour
{
    [SerializeField] private CollectedScript collectedScript;

    // if player inside, close the collectUI
    private void OnTriggerEnter(Collider other)
    {
        collectedScript.SetArea(3);
    }
}
