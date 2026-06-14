using UnityEngine;

public class a1script : MonoBehaviour
{
    [SerializeField] private CollectedScript collectedScript;

    // if player inside, close the collectUI
    private void OnTriggerEnter(Collider other)
{
    collectedScript.SetArea(1);
}
}