using UnityEngine;

/*
* Author: Carolyn
* Date: 13/07/26
* Description: Short tutorial pop up to disappear once you leave the starting room
*/

public class ControlsUIScript : MonoBehaviour
{
    [SerializeField] private GameObject ControlsCanvas;
    // for collectUI update
    [SerializeField] private CollectedScript collectedScript;

    // upon player exiting the trigger, close the controls
    // if controlscanvas is active, close it
    void OnTriggerExit(Collider other)
    {
        if (ControlsCanvas.activeSelf)
        {
            ControlsCanvas.SetActive(false);
            collectedScript.SetArea(1);
        }
    }
}
