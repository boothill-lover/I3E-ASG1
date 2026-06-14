using UnityEngine;
using TMPro;
using UnityEngine.UI;

/*
* Author: Carolyn
* Date: 
* Description:
*/


public class PlayerScript : MonoBehaviour
{
    // create a bool to track whether player has obtained the hammer
    public bool hasHammer = false;
    // get the hint for hammer
    [SerializeField] private GameObject hintPanel;

    // get the crosshair to highlight when nearby interactable items
    [SerializeField] private Image crosshair;
    // get the ui script
    [SerializeField] private CollectedScript collectedScript;
    public GameObject currentCollectible;
    AudioSource collectibleAudio;

    void Start()
    {
        collectibleAudio = GetComponent<AudioSource>();
    }
     void OnTriggerEnter(Collider other)
    {
        // if it can be collected
        if(other.gameObject.tag == "spinningfood")
        {
            currentCollectible = other.gameObject;
            crosshair.color = Color.red;

        }

        if(other.gameObject.tag == "blockedfood")
        {
            crosshair.color = Color.yellow;
        }

       /* 
        Door door = other.GetComponentInParent<Door>();

        if(door != null)
        {
            currentDoor = other.gameObject;
            currentDoorScript = door;
        }
        */
    }

    public void OnInteract()
    {
        // if current collectible isnt null, collect it
        if(currentCollectible != null)
        {
            CollectibleScript collectible = currentCollectible.GetComponent<CollectibleScript>();

            if (collectible != null)
            {
                // printing to console to debug
                GameManager.totalScore += collectible.score;
                print("Collected: " + collectible.score + "points. Total Score: " + GameManager.totalScore);

                // to update the UI
                collectedScript.CollectItem(collectible.areaID);
                collectible.Collect();
                // reset the currentcollectible aft collecting
                currentCollectible = null;
            }
        }

        // if looking at a blocked food
        if(crosshair.color == Color.yellow)
        {
            hintPanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == currentCollectible)
        {
            // collectible out of range
            currentCollectible = null;
            crosshair.color = Color.white;
        }
    }
}
