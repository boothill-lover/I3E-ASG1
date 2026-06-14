using UnityEngine;
using TMPro;
using UnityEngine.Events;
using StarterAssets;

/*
* Author: Carolyn
* Date: 12/07/26
* Description: Controls what happens with my notebook (salmon) 
*/

public class NoteController : MonoBehaviour
{
    [Header("Input")]
    [Space(10)]
    [SerializeField] private FirstPersonController player;

    [Header("UI Text")]
    [SerializeField] private GameObject noteCanvas;
    [SerializeField] private TMP_Text noteTextAreaUI;

    // editable text
    [Space(10)]
    [SerializeField] [TextArea] private string noteText;

    // event for when i interact with the note, e.g. audio (i watched a youtube tutorial on this)
    [Space(10)]
    [SerializeField] private UnityEvent openEvent;

    [Space(10)]
    // my controls ui
    [Header("Controls Tutorial")]
    [SerializeField] private GameObject ControlsCanvas;

    private bool isOpen = false;
    public void ShowNote()
    {
        noteTextAreaUI.text = noteText;
        // show note canvas and hide the controls
        noteCanvas.SetActive(true);
        ControlsCanvas.SetActive(false);
        openEvent.Invoke();

        // disable player movement when note open
        DisablePlayer(true);
        isOpen = true;
    }

    void DisableNote()
    {
        // hide note and show controls
        noteCanvas.SetActive(false);
        ControlsCanvas.SetActive(true);
        // enable player
        DisablePlayer(false);
        isOpen = false;
    }

    void DisablePlayer(bool disable)
    {
        player.enabled = !disable;
    }

    private void Update()
    {
        if (isOpen)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                DisableNote();
            }
        }
    }
}
