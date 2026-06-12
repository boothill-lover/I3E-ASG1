using UnityEngine;

public class foodSpin : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 30f * Time.deltaTime, 0);
    }
}
