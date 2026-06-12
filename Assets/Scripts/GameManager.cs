using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int totalPossibleScore = 0;
    public static int totalScore = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] collectibleObjects = GameObject.FindGameObjectsWithTag("spinningfood");
        foreach (GameObject obj in collectibleObjects)
        {
            CollectibleScript collectible = obj.GetComponent<CollectibleScript>();
            if (collectible != null)
            {
                totalPossibleScore += collectible.score;
            }
        }

        print("Total possible score: " + totalPossibleScore);
    }
}
