/* 
* Author: Yeong Yu Seong
* Date: 11 June 2025
* Description: This script is used for Area C of the game. It is used to check all the fuse slots to activate doors and lights.
* Credits: This code is implemented with the help of ChatGPT.
*/
using UnityEngine;

public class PowerRoomBehaviour : MonoBehaviour
{
    /// <summary>
    ///  Store all the fuse slots
    /// </summary>
    public FuseSlotBehaviour[] slots;
    /// <summary>
    /// Store all the lights to be set active in the room once all the fuse had been correctly placed
    /// </summary>
    public Light[] roomLights;
    /// <summary>
    /// Set the intensity of the lights
    /// </summary>
    public float brightIntensity = 100f;
    /// <summary>
    ///  Checks if all fuses are correct
    /// </summary>
    bool isPoweredUp = false;
    /// <summary>
    /// Store a door where the door will open once all the fuse is correctly placed
    /// </summary>
    public GameObject doorToOpen;
    /// <summary>
    /// Audio for when the door opens
    /// </summary>
    AudioSource doorSound;
    /// <summary>
    /// Runs through each fuse slot and checks the status of the correct variable in FuseSlotBehaviour script
    /// If all correct, return true
    /// If at least one wrong, return false
    /// </summary>
    /// <returns></returns>
    bool AllFusesCorrect()
    {
        foreach (var slot in slots)
        {
            if (!slot.correct) return false;
        }
        return true;
    }
    /// <summary>
    /// Activates all the lights
    /// </summary>
    void PowerUpRoom()
    {
        foreach (var lights in roomLights)
        {
            lights.intensity = brightIntensity; // Set the intensity of the lights
            lights.enabled = true; // Enable the lights
        }
        RenderSettings.ambientIntensity = 1f; // Set ambient intensity
        isPoweredUp = true; // All fuses are correct
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorSound = GetComponent<AudioSource>(); // Get sound
    }

    // Update is called once per frame
    void Update()
    {
        // Opens the door
        if (AllFusesCorrect() && !isPoweredUp) // Check if all fuses are correct
        {
            doorToOpen.transform.position = new Vector3(-68.5f, 5f, -19f); // Open the door
            doorSound.Play(); // Play sound when door opens
            PowerUpRoom();
            this.enabled = false; // Stop running this script
        }
    }
}
