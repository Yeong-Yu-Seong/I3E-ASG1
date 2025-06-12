/* 
* Author: Yeong Yu Seong
* Date: 11 June 2025
* Description: This script is used to check if the fuses are placed in the correct fuse slot.
* Credits: This code is implemented with the help of ChatGPT.
*/
using UnityEngine;

public class FuseSlotBehaviour : MonoBehaviour
{
    /// <summary>
    /// ID of the fuse slot, public so that each fuse slot will have a different ID
    /// </summary>
    [SerializeField]
    public string correctFuseID;
    /// <summary>
    /// The state of whether the fuse is correctly inserted
    /// </summary>
    public bool correct = false;
    /// <summary>
    /// The sound that will play when the fuse is correctly inserted
    /// </summary>
    AudioSource correctFuseAudio;
    /// <summary>
    /// Store the ErrorManager script in a variable called errorUI
    /// </summary>
    private ErrorManager errorUI;
    /// <summary>
    /// Check if the player insert the fuse correctly
    /// If wrong, fuse will respawn and error message will be shown
    /// </summary>
    /// <param name="fuse"></param>
    public void InsertFuse(GameObject fuse)
    {
        string fuseID = fuse.GetComponent<FuseBehaviour>().fuseID;
        if (fuseID == correctFuseID)
        {
            if (!correct)
            {
                correct = true;
                correctFuseAudio.Play();
                PlayerBehaviour player = FindObjectOfType<PlayerBehaviour>(); // Get the PlayerBehaviour script and naming it player
                if (player != null)
                {
                    player.IncrementFuseCount(); // Increase the fuse count
                }
            }
        }
        else
        {
            // Respawn the fuse
            Renderer rend = fuse.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.enabled = true;
            }
            Collider col = fuse.GetComponent<Collider>();
            if (col != null)
            {
                col.enabled = true;
            }
            // Show error message
            if (errorUI != null)
            {
                errorUI.ShowError("Error: Fuse placed in wrong slot.");
            }
        }
    }
    void Start()
    {
        correctFuseAudio = GetComponent<AudioSource>(); // Get the audio to be played
        errorUI = FindObjectOfType<ErrorManager>(); // Get the ErrorManager script
    }
    // Update is called once per frame
    void Update()
    {

    }
}
