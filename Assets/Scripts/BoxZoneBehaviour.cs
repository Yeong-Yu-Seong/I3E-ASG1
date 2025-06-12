/* 
* Author: Yeong Yu Seong
* Date: 11 June 2025
* Description: This script is used to track whether the boxes in Area A are in the green zone. It is also used to activate CardA.
* Credits: This code is implemented with the help of ChatGPT.
*/
using UnityEngine;

public class BoxZoneBehaviour : MonoBehaviour
{
    /// <summary>
    /// Count how many boxes are inside the green zone
    /// </summary>
    private int boxesInside = 0;
    /// <summary>
    /// Store the PlayerBehaviour script in a variable called player
    /// </summary>
    [SerializeField]
    private PlayerBehaviour player;
    /// <summary>
    /// When a box enters the green zone, increase the box count
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            boxesInside++; // Increase box count
            CheckBoxes();
        }
    }
    /// <summary>
    /// When a box exit the green zone, decrease the box count
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            boxesInside--; // Decrease the box count
            player.UpdateBoxProgress(boxesInside, 3); // Update Progress UI
        }
    }
    /// <summary>
    /// Check the number of boxes in the green zone
    /// </summary>
    void CheckBoxes()
    {
        player.UpdateBoxProgress(boxesInside, 3); // Update Progress UI
        /* Check if all the boxes are in
           If all are in, enable the card
        */
        if (boxesInside == 3)
        {
            player.CompleteTask(); // Update Task UI
            GameObject card = GameObject.FindWithTag("CardA"); // Get the card to enable
            if (card != null)
            {
                Renderer rend = card.GetComponent<Renderer>();
                if (rend != null) rend.enabled = true;

                Collider col = card.GetComponent<Collider>();
                if (col != null) col.enabled = true;
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
