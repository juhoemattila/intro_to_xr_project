using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPositionSwitcher : MonoBehaviour
{
    public Transform RoomPOV; // Transform for the room position
    public Transform ExternalPOV; // Transform for the external viewing point
    public InputActionReference togglePositionAction; // Reference to the Input Action for the button press

    private bool isInRoom = true; // Track whether the player is in the room

    void Start()
    {
        // Set the initial position to the room
        if (RoomPOV != null)
        {
            SwitchToPosition(RoomPOV);
        }

        // Enable the input action
        togglePositionAction.action.Enable();
    }

    void Update()
    {
        // Check if the button was pressed
        if (togglePositionAction.action.triggered)
        {
            // Toggle the player's position
            if (isInRoom)
            {
                SwitchToPosition(ExternalPOV);
            }
            else
            {
                SwitchToPosition(RoomPOV);
            }

            // Flip the state
            isInRoom = !isInRoom;
        }
    }

    private void SwitchToPosition(Transform targetPosition)
    {
        if (targetPosition != null)
        {
            // Move the player to the target position
            transform.position = targetPosition.position;

            // Optionally set the rotation (if needed)
            transform.rotation = targetPosition.rotation;
        }
        else
        {
            Debug.LogError("Target position is not set!");
        }
    }

    void OnDisable()
    {
        // Disable the input action when the script is disabled
        togglePositionAction.action.Disable();
    }
}
