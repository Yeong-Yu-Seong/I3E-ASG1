/* 
* Author: Yeong Yu Seong
* Date: 11 June 2025
* Description: This script is used to enable and disable error messages.
* Credits: This code is implemented with the help of ChatGPT.
*/
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ErrorManager : MonoBehaviour
{
    /// <summary>
    /// Text box for the error to be shown
    /// </summary>
    [SerializeField]
    TextMeshProUGUI errorText;
    /// <summary>
    /// Background for the error message
    /// </summary>
    [SerializeField]
    Image errorBackground;
    /// <summary>
    /// Timer
    /// </summary>
    private float timer = 0f;
    /// <summary>
    /// The state of the error message
    /// true = error message is being shown
    /// false = error message not being shown
    /// </summary>
    private bool isShowing = false;
    void Start()
    {
        errorText.enabled = false; // Set error text to not be showing
        errorBackground.enabled = false; // Set error background to not be showing
    }
    void Update()
    {
        // If error message is showing, start the timer and hide the message after 5 seconds
        if (isShowing)
        {
            timer += Time.deltaTime; // Increase timer
            // After 5 seconds, hide the error message
            if (timer > 5f)
            {
                HideError();
            }
        }
    }
    /// <summary>
    /// Show the error message
    /// </summary>
    /// <param name="message"></param>
    public void ShowError(string message)
    {
        errorText.text = message; // Set the error text
        errorText.enabled = true; // Enable the error text
        errorBackground.enabled = true; // Enable the error background
        timer = 0f; // Reset timer
        isShowing = true;
    }

    private void HideError()
    {
        errorText.enabled = false; // Disable the error text
        errorBackground.enabled = false; // Disable the error background
        isShowing = false;
    }
}