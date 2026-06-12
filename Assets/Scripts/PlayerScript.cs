using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    GameObject currentCollectible;
    AudioSource collectibleAudio;

    void Start()
    {
        collectibleAudio = GetComponent<AudioSource>();
    }
     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "spinningfood")
        {
            currentCollectible = other.gameObject;
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
        }
    }
}
