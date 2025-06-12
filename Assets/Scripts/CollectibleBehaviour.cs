/* 
* Author: Yeong Yu Seong
* Date: 11 June 2025
* Description: This script is used for the collection of collectibles. It also spins the collectibles.
*/
using UnityEngine;

public class CollectibleBehaviour : MonoBehaviour
{
    /// <summary>
    /// The amount each collectible is worth
    /// </summary>
    [SerializeField]
    public int collectibleScore = 1;
    /// <summary>
    /// Sound to be played when collecting the collectible
    /// </summary>
    [SerializeField]
    AudioClip collectibleSound;
    /// <summary>
    /// Collect the collectible
    /// </summary>
    /// <param name="player"></param>
    public void CollectCollectible(PlayerBehaviour player)
    {
        player.ModifyScore(collectibleScore); // Increase palyer's score
        Destroy(gameObject); // Remove the item from the game
        AudioSource.PlayClipAtPoint(collectibleSound, transform.position); // Play the sound when collected
    }
    Vector3 rotationSpeed = new Vector3(0, 100, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
