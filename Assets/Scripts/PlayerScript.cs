using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Image crosshair;
    public GameObject currentCollectible;
    AudioSource collectibleAudio;

    // to update UI
    public static int a1amount = 0;
    [SerializeField] private TMP_Text collected;

    void Start()
    {
        collectibleAudio = GetComponent<AudioSource>();
    }
     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "spinningfood")
        {
            currentCollectible = other.gameObject;
            crosshair.color = Color.red;

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
                GameManager.totalScore += collectible.score;
                print("Collected: " + collectible.score + "points. Total Score: " + GameManager.totalScore);
                collectible.Collect();

                a1amount += 1;

                // update the ui
                collected.text = "Area 1\nCollected: " + a1amount + "/6";

                // reset the currentcollectible aft collecting
                currentCollectible = null;
            }
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
