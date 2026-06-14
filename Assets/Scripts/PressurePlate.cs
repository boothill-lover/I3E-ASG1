using UnityEngine;

/*
* Author: Carolyn
* Date: 12/07/26
* Description: Pressure plates detection of me and the apple
*/

public class PressurePlate : MonoBehaviour
{
    public bool isPressed;

    // number of objects on the pressure plate
    private int pushCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        // only player and apple allowed to open plate
        if (other.CompareTag("pushable") || other.CompareTag("Player"))
        {
            // increase count when one enters
            pushCount++;
            isPressed = pushCount > 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // if object leaves plate
        if (other.CompareTag("pushable") || other.CompareTag("Player"))
        {
            pushCount--;

            // in case of negatives
            if (pushCount < 0)
            {
                pushCount = 0;    
            }

            // update the state
            isPressed = pushCount > 0;
        }
    }
}