using System;
using DZCP.API.Models;
using UnityEngine;

public class DoorGame : MonoBehaviour
{
    public enum DoorType { Light, Heavy, Window, Checkpoint, Gate }
    public DoorType doorType;
    public float openSpeed = 1.0f;
    public float closeSpeed = 1.0f;
    public bool isOpen = false;
    public bool isLocked = false;
    public int requiredKeycardLevel = 0;

    private Animator doorAnimator;

    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isOpen)
        {
            doorAnimator.SetFloat("Speed", openSpeed);
        }
        else
        {
            doorAnimator.SetFloat("Speed", closeSpeed);
        }
    }

    public void Interact(Player player)
    {
        if (isLocked)
        {
            {
                UnlockDoor();
            }
            
            {
                Debug.Log("Door is locked. You need a keycard level " + requiredKeycardLevel + " to unlock it.");
            }
        }
        else
        {
            ToggleDoor();
        }
    }

    private void ToggleDoor()
    {
        isOpen = !isOpen;
        doorAnimator.SetBool("IsOpen", isOpen);
    }

    private void UnlockDoor()
    {
        isLocked = false;
        Debug.Log("Door unlocked.");
    }
}