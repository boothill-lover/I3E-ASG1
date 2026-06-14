using UnityEngine;
using TMPro;
using UnityEngine.UI;

/*
* Author: Carolyn
* Date: 12/07/26
* Description: Script for my Player, contains what to do if the player interacts with objects.
*/


public class PlayerScript : MonoBehaviour
{
    // create a bool to track whether player has obtained the hammer
    public bool hasHammer = false;
    // get the hint for hammer
    [SerializeField] private GameObject hintPanel;

    // my two jarred foods
    [SerializeField] private GameObject cheese;
    [SerializeField] private GameObject frappe;

    // get the crosshair to highlight when nearby interactable items
    [SerializeField] private Image crosshair;
    // get the ui script
    [SerializeField] private CollectedScript collectedScript;
    public GameObject currentCollectible;
    AudioSource collectibleAudio;

    // timer for my ui to disappear
    private float hideTimer;

    // door interaction
      GameObject currentDoor;
    doorscript currentDoorScript;

    // hint text
    [SerializeField] private TMP_Text hintText;


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
            currentCollectible = other.gameObject;
        }

        if(other.gameObject.tag == "hammer")
        {
            crosshair.color = Color.cyan;
            currentCollectible = other.gameObject;
        }
       
        doorscript door = other.GetComponentInParent<doorscript>();

        if(door != null)
        {
            currentDoor = other.gameObject;
            currentDoorScript = door;
        }
        
    }

    // show hint for a bit
    public void ShowHint()
    {
        if(hasHammer == false)
        {
                hintText.text = "Maybe something can break this jar...";
        }

        else
        {
            hintText.text = "You can now break jars! Yay";
        }
        hintPanel.SetActive(true);
        hideTimer = 3f;
    }


    public void OnInteract()
    {
        // if current collectible isnt null, collect it
        if(currentCollectible != null)
        {
            CollectibleScript collectible = currentCollectible.GetComponent<CollectibleScript>();

            // check for hammer
            if (currentCollectible.CompareTag("hammer"))
            {
                hasHammer = true;

                ShowHint();

                collectible.Collect();
                currentCollectible = null;
                return;
            }

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
            // checks parent name of the jar
            Transform root = currentCollectible.transform.root;
            // if u have hammer, break the jar.
            if(hasHammer)
            {
                if (root.name == "A1_jar_cheese")
                {
                    cheese.tag = "spinningfood";
                }
                else if (root.name == "A1_jar_frappe")
                {
                    frappe.tag = "spinningfood";
                }

                // then destroy jar
                Destroy(currentCollectible);
                crosshair.color = Color.red;
            }
            
            // if not, show hint that you need one
            else
            {
                ShowHint();
            }
            
        }

        if(currentDoorScript != null)
            {
                currentDoorScript.Interact();
            }
    } // onInteract()

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == currentCollectible)
        {
            // collectible out of range
            currentCollectible = null;
            crosshair.color = Color.white;
        }

         if(other.gameObject == currentDoor)
        {
            // door out of range
            currentDoor = null;
            currentDoorScript = null;
        }
    }

    // resets the timer, i tried coroutine and it wasn't working.
    void Update()
    {
        if (hideTimer > 0f)
        {
            hideTimer -= Time.deltaTime;

            if (hideTimer <= 0f)
            {
                hintPanel.SetActive(false);
            }
        }

    }

}
