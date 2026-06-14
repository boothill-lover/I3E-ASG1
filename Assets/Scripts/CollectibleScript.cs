using UnityEngine;
using UnityEngine.UI;

/*
* Author: Carolyn
* Date: 12/07/26
* Description: For my collectibles like food, stores what to do with the food when you interact with it
*/

public class CollectibleScript : MonoBehaviour
{
    // get crosshair img
    [SerializeField] private Image crosshair;

    // manually able to set score value
    public int score = 1;
    // manually able to set which area this food is from
    public int areaID;
    AudioSource collectibleAudio;

    void Start()
    {
        // get the audio given to the ob
        collectibleAudio = GetComponent<AudioSource>();
    }

    public void Collect()
    {
        if(collectibleAudio != null)
        {
            collectibleAudio.Play();
            // destroy game object parent after playing audio
            Destroy(gameObject.transform.parent.gameObject, collectibleAudio.clip.length);
            crosshair.color = Color.white;
        }
        
        else
        {
            // um if there is no audio its okay just destroy it
            Destroy(gameObject.transform.parent.gameObject);
            crosshair.color = Color.white;
        }
    }

}
