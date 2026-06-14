using UnityEngine;

/*
* Author: Carolyn
* Date: 14/07/26
* Description: Script for my door animations.
*/

public class doorscript : MonoBehaviour
{
    public Animator anim;
    bool isOpen = false;
    private float closeTimer;


    public void Interact()
    {
        if(isOpen)
        {
            anim.SetTrigger("doorclose");
            closeTimer = 0f;
        }
        else
        {
            anim.SetTrigger("dooropen");
            closeTimer = 3f;
        }
    }

    void Update()
    {
        if (closeTimer > 0f)
        {
            closeTimer -= Time.deltaTime;

            if (closeTimer <= 0f)
            {
                anim.SetTrigger("doorclose");
                isOpen = false;
            }
        }

    }
}
