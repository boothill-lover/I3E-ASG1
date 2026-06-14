using UnityEngine;

/*
* Author: Carolyn
* Date: 12/07/26
* Description: Script for the door that will activate when pressure plates are pressed
*/


public class PPDoor : MonoBehaviour
{
    public PressurePlate plate1;
    public PressurePlate plate2;

    // how high and fast i want the door to go
    public float moveHeight = 5f;
    public float speed = 3f;

    private Vector3 startPos;
    private Vector3 targetPos;

    // locks door so it never closes again
    private bool permanentlyOpen = false;

    void Start()
    {   
        // current pos = startpos
        startPos = transform.position;

        targetPos = startPos + Vector3.up * moveHeight;
    }

    void Update()
    {
        // door opens only when both plates are pressed (one-time trigger)
        if (!permanentlyOpen && plate1.isPressed && plate2.isPressed)
        {
            permanentlyOpen = true;
        }

        // target pos based on whether its open or closed
        Vector3 goal = permanentlyOpen ? targetPos : startPos;

        // moving
        transform.position = Vector3.Lerp(transform.position, goal, Time.deltaTime * speed);
    }
}