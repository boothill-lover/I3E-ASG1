using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class raycast : MonoBehaviour
{

    [Header("Raycast Features")]
    [SerializeField] private float rayLength = 5;
    private Camera _camera;

    private NoteController _noteController;

    [Header("Crosshair")]
    [SerializeField] private Image crosshair;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        // no matter where it is it will always be in the center of the screen
        if(Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit hit, rayLength))
        {
            var readableItem = hit.collider.GetComponent<NoteController>();
            if (readableItem != null)
            {
                _noteController = readableItem;
                // highlightCrosshair
                HighlightCrosshair(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(_noteController != null)
                {
                    _noteController.ShowNote();
                }
                }
                

            }
            else
            {
                // Clear Readable Item
                ClearNote();
            }
        }

        else
        {
            // Clear Readable Item
            ClearNote();
        }

        
    }

    void ClearNote()
    {
        if(_noteController != null)
        {
            // Disable crosshair 
            HighlightCrosshair(false);
            _noteController = null;
        }
        
        
    }

    // highlight crosshair when looking at note
    void HighlightCrosshair(bool on)
    {
        if (on)
        {
            crosshair.color = Color.red;
        }

        else
        {
            crosshair.color = Color.white;
        }
    }
}
