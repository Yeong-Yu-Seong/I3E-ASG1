/* 
* Author: Yeong Yu Seong
* Date: 11 June 2025
* Description: This script is used for wire collection
*/
using UnityEngine;

public class WireBehaviour : MonoBehaviour
{
    /// <summary>
    /// The amount each wire is worth
    /// </summary>
    int wireCount = 1;
    /// <summary>
    /// Collects the wire
    /// </summary>
    /// <param name="player"></param>
    public void CollectWire(PlayerBehaviour player)
    {
        player.WireCount(wireCount); // Increases the wire count in the PlayerBehaviour script
        Destroy(gameObject); // Remove the object from the game
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
