using UnityEngine;

public class blockedFood : MonoBehaviour
{
    public GameObject insideFood; // the real collectible
    public GameObject brokenJar;

    public void Break()
    {
        // "break" jar
        brokenJar.SetActive(false);

    }
}