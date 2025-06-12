/* 
* Author: Yeong Yu Seong
* Date: 11 June 2025
* Description: This script is used to activate the card for AreaB once 6 wires are collected.
*/
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    /// <summary>
    /// Store the PlayerBehaviour script in a variable called player
    /// </summary>
    public PlayerBehaviour player;
    /// <summary>
    /// Set the card to be spawned to false
    /// </summary>
    private bool cardEnabled = false;
    /// <summary>
    /// A renderer component in a variable called rend
    /// </summary>
    private Renderer rend;
    /// <summary>
    /// A collider component in a variable called col
    /// </summary>
    private Collider col;

    void Start()
    {
        rend = GetComponent<Renderer>(); // Get the renderer component
        col = GetComponent<Collider>(); // Get the collider component

        // Card is set as "inactive"/ invisible
        if (rend != null)
        {
            rend.enabled = false;
        }

        if (col != null)
        {
            col.enabled = false;
        }
    }

    void Update()
    {
        // If player had collected 6 wires, the card spawns
        if (!cardEnabled && player != null && player.wiresNo == 6)
        {
            EnableCard();
        }
    }
    /// <summary>
    /// Spawns the card
    /// </summary>
    void EnableCard()
    {
        if (rend != null)
        {
            rend.enabled = true;
        }

        if (col != null)
        {
            col.enabled = true;
        }

        cardEnabled = true;
        player.wiresNo = 0; // Reset the wire count in the PlayerBehaviour script to 0
    }
}
