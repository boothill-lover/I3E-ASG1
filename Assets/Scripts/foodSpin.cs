using UnityEngine;

/*
* Author: Carolyn
* Date: 12/07/26
* Description: Script to make my food spin
*/

public class foodSpin : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 30f * Time.deltaTime, 0);
    }
}
