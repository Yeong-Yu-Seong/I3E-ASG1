/* 
* Author: Yeong Yu Seong
* Date: 11 June 2025
* Description: This script is used for the interaction of doors
*/
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    /// <summary>
    /// Audio for when the door opens
    /// </summary>
    AudioSource doorSound;
    /// <summary>
    /// Interact with the door - open the door
    /// </summary>
    public void Interact()
    {
        Vector3 doorRotation = transform.eulerAngles; // Get the current angles (x,y,z) of the door
        if (gameObject.CompareTag("Door")) // Check if the door is a left door
        {
            doorRotation.y -= 90f; // Increase the angle of y 
        }
        else if (gameObject.CompareTag("Door_RTurn")) // Check if the door is a right door
        {
            doorRotation.y += 90f; // Decrease the angle of y
        }
        transform.eulerAngles = doorRotation; // Apply the rotation
        doorSound.Play(); // Play sound when interact with the door
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorSound = GetComponent<AudioSource>(); // Get sound
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
