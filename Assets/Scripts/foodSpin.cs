using UnityEngine;

public class foodSpin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject[] items;

    void Start()
    {
        // find all objects with the spinning food tag and store it 
        items = GameObject.FindGameObjectsWithTag("spinningfood");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject item in items)
        {
            item.transform.Rotate(0, 30f * Time.deltaTime, 0);
        }
    }
}
