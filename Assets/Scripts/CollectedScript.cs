using UnityEngine;
using TMPro;

/*
* Author: Carolyn
* Date: 13/07/26
* Description: Script for the UI that indicates what area I'm in and how much I've collected in said area.
*/


public class CollectedScript : MonoBehaviour
{
    // get collectibles
    [SerializeField] private PlayerScript player;

    public static int a1amount, a2amount, s1amount = 0;

    // defines what area im currently in
    public int currentArea = 0;
    // collect ui
    [SerializeField] private TMP_Text collected;
    [SerializeField] private GameObject collectUI;
    void Start()
    {
        currentArea = 0;
        collectUI.SetActive(false);
    }

    public void CollectItem(int areaID)
{
    if (areaID == 1)
    {
        a1amount++;
        collected.text = "Area 1\nCollected: " + a1amount + "/6";
    }

    else if (areaID == 99)
        {
            s1amount++;
            collected.text = "Secret Area\nCollected: " + s1amount + "/2";
        }
}

// for changing area in the area triggers scripts
public void SetArea(int area)
{
    currentArea = area;
    UpdateUI();
}

public void UpdateUI()
{
    if (currentArea == 0)
        {
            // if current area is 0 aka starting room, disable the ui
            collectUI.SetActive(false);
        }

    else
        {
            collectUI.SetActive(true);
            if (currentArea == 1)
            {
                collected.text = "Area 1\nCollected: " + a1amount + "/6";
            }
            else if (currentArea == 2)
            {
                collected.text = "Area 2\nCollected: " + a2amount + "/5";
            }
            else if (currentArea == 99)
            {
                collected.text = "Secret Area\nCollected: " + s1amount + "/2";
            }

        }
}

}
