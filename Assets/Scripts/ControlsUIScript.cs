using UnityEngine;

public class ControlsUIScript : MonoBehaviour
{
    [SerializeField] private GameObject ControlsCanvas;

    // upon player exiting the trigger, close the controls

    // if controlscanvas is active, close it
    void OnTriggerExit(Collider other)
    {
        if (ControlsCanvas.activeSelf)
        {
            ControlsCanvas.SetActive(false);
        }
    }
}
