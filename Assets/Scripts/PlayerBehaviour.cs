/* 
* Author: Yeong Yu Seong
* Date: 11 June 2025
* Description: This script is the main script for the game
* Credits: This code is implemented with the help of ChatGPT.
*/
using UnityEngine;
using TMPro;
using StarterAssets;
using System.Collections.Generic;
using System.Collections;


public class PlayerBehaviour : MonoBehaviour
{
    /// <summary>
    /// Store the object that was last highlighted
    /// </summary>
    GameObject lastHighlightedObject;
    /// <summary>
    /// Store the orginal material of the object
    /// </summary>
    Material originalMaterial;
    /// <summary>
    /// Store the material that will be shown when the object is highlighted
    /// </summary>
    [SerializeField]
    Material highlightMaterial;
    /// <summary>
    /// Player's current score
    /// </summary>
    int currentScore = 0;
    /// <summary>
    /// Store the current wire the player is interacting with
    /// </summary>
    WireBehaviour currentWire;
    /// <summary>
    /// Keep track of the number of the wire the player have collected
    /// </summary>
    public int wiresNo = 0;
    /// <summary>
    /// Check if the item to be interacted with is a wire
    /// </summary>
    bool isWire = false;
    /// <summary>
    /// Check if the item to be interacted with is a collectible
    /// </summary>
    bool isCollectible = false;
    /// <summary>
    /// Store the current collectible the player is interacting with
    /// </summary>
    CollectibleBehaviour currentCollectible;
    /// <summary>
    /// Check if the item can be interacted
    /// </summary>
    bool canInteract = false;
    /// <summary>
    /// Store the current fuse slot the player is interacting with
    /// </summary>
    FuseSlotBehaviour currentSlot;
    /// <summary>
    /// Store the current door the player is interacting with
    /// </summary>
    DoorBehaviour currentDoor;
    /// <summary>
    /// Store the current card the player is interacting with
    /// </summary>
    GameObject cardObject;
    /// <summary>
    /// Check if the item to be interacted with is a card
    /// </summary>
    bool isCard = false;
    /// <summary>
    /// Store the current fuse the player is holding
    /// </summary>
    GameObject heldFuse;
    /// <summary>
    /// Check if the player is holding a fuse
    /// </summary>
    bool hasFuse = false;
    /// <summary>
    /// The total number of planks needed to collect
    /// </summary>
    int planksNeeded = 3;
    /// <summary>
    /// The total number of planks the player collected
    /// </summary>
    int planksCollected = 0;
    /// <summary>
    /// Store the dock platforms that needs to be activated via plank collection
    /// </summary>
    public GameObject[] platformPlanks;
    /// <summary>
    /// Player's current health
    /// </summary>
    int health = 100;
    /// <summary>
    /// Raycast location
    /// </summary>
    [SerializeField]
    Transform spawnPoint;
    /// <summary>
    /// Raycast distance
    /// </summary>
    float interactionDistance = 1f;
    /// <summary>
    /// Check if the item to be interacted with is a plank
    /// </summary>
    bool isPlank = false;
    /// <summary>
    /// Store the current plank the player is interacting with
    /// </summary>
    GameObject currentPlank;
    /// <summary>
    /// Text box to show the player's score
    /// </summary>
    [SerializeField]
    TextMeshProUGUI scoreText;
    /// <summary>
    /// Text box to show the player's current objective
    /// </summary>
    [SerializeField]
    TextMeshProUGUI taskText;
    /// <summary>
    /// Text box to show the player's current health
    /// </summary>
    [SerializeField]
    TextMeshProUGUI healthText;
    /// <summary>
    /// Store the current card the player is going to need to use
    /// </summary>
    GameObject currentCard;
    /// <summary>
    /// Location that the player will respawn at when the player touches the toxic
    /// </summary>
    [SerializeField]
    Transform tpTarget;
    /// <summary>
    /// Text box to show current progress on the current task
    /// </summary>
    [SerializeField]
    TextMeshProUGUI progressText;
    /// <summary>
    /// A collection of all the tasks to be shown to the player
    /// </summary>
    string[] tasks = {
    "Push 3 boxes into the green zone", // Task 1
    "Collect the 6 wires scattered around", // Task 2
    "Connect all the fuses correctly to unlock the dock area", // Task 3
    "Collect the 3 planks to activate all the platforms" // Task 4
    };
    /// <summary>
    /// Task counter
    /// </summary>
    int currentTaskIndex = 0;
    /// <summary>
    /// Number of correct fuses
    /// </summary>
    int insertedFuses = 0;
    /// <summary>
    /// Text box to show the score of the player once the game ends
    /// </summary>
    [SerializeField]
    TextMeshProUGUI endscoreText;
    /// <summary>
    /// A dictionary to store all the orginal materials of the object
    /// </summary>
    Dictionary<Renderer, Material> originalMaterials = new Dictionary<Renderer, Material>();
    /// <summary>
    /// Location the player will be tp to when player fall off the map
    /// </summary>
    [SerializeField]
    Transform tpTarget2;
    /// <summary>
    /// Sound to be played when the player touches a wire
    /// </summary>
    AudioSource wireSound;
    /// <summary>
    /// Store the ErrorManager script in a variable called errorUI
    /// </summary>
    [SerializeField]
    private ErrorManager errorUI;
    /// <summary>
    /// Check if the player is respawning
    /// </summary>
    private bool isRespawning = false;
    /// <summary>
    /// Increases the player's score
    /// </summary>
    /// <param name="amount"></param>
    public void ModifyScore(int amount)
    {
        currentScore += amount;
    }
    /// <summary>
    /// Increases the wiresNo whenever a wire is collected
    /// </summary>
    /// <param name="amount"></param>
    public void WireCount(int amount)
    {
        wiresNo += amount;
        progressText.text = $"Wires: {wiresNo}/6";
        if (wiresNo == 6)
        {
            CompleteTask();
        }
    }
    /// <summary>
    /// Update Progress UI
    /// </summary>
    /// <param name="current"></param>
    /// <param name="total"></param>
    public void UpdateBoxProgress(int current, int total)
    {
        progressText.text = $"Boxes: {current}/{total}";
    }
    /// <summary>
    /// Increases fuse count
    /// Updates Progress UI
    /// </summary>
    public void IncrementFuseCount()
    {
        insertedFuses++; // Increase fuse count
        progressText.text = $"Fuses: {insertedFuses}/3"; // Update Progress UI
        // Check if all the fuses are inserted
        if (insertedFuses == 3)
        {
            CompleteTask(); // Move on to next task
        }
    }
    /// <summary>
    /// All the possible interactions the player can do by pressing 'E'
    /// </summary>
    void OnInteract()
    {
        if (canInteract)
        {
            // Collects card if it is a card and not interacting with the door
            if (isCard && cardObject != null && currentDoor == null)
            {
                cardObject.SetActive(false); // Hide the card visually
                isCard = true; // True so it can unlock the door later
                currentCard = cardObject; // Store the card
            }
            // Use the card when interacting with a door
            else if (currentCard && currentDoor != null)
            {
                currentDoor.Interact(); // Open door
                currentCard = null; // Discard the card
                currentDoor = null; // Makes sure it is not interacting with the door anymore
            }
            // If the player is interacting with a door but does not have a card
            else if (currentCard == null && currentDoor != null)
            {
                errorUI.ShowError("Door locked!"); // Show error message
            }
            // Collects the item if it is a collectible
            else if (isCollectible)
            {
                currentCollectible.CollectCollectible(this); // Collect the collectible
                scoreText.text = "SCORE: " + currentScore.ToString(); //Update the Score UI
                isCollectible = false; // Makes sure it does not collect anything else
                currentCollectible = null; // Makes sure it is not interacting with the collectible anymore
            }
            // Collects the item if it is a wire
            else if (isWire)
            {
                currentWire.CollectWire(this); // Collect the wire
                isWire = false; // Makes sure it does not collect anything else
                currentWire = null; // Makes sure it is not interacting with the wire anymore
            }
            // Uses the fuse the player is holding on the fuse slot
            else if (hasFuse && currentSlot != null)
            {
                currentSlot.InsertFuse(heldFuse); // Use the fuse on the fuse slot
                hasFuse = false; // Makes sure the player don't have the fuse anymore
                heldFuse = null; // Discard the fuse
            }
            // Collects the item if it is a plank
            else if (isPlank)
            {
                planksCollected++; // Increase total plank collected
                Destroy(currentPlank); // Remove collected plank
                // Activate the dock platform whenever a plank is collected
                if (planksCollected <= platformPlanks.Length)
                {
                    platformPlanks[planksCollected - 1].SetActive(true); // Activate one plank
                    progressText.text = $"Planks: {planksCollected}/{planksNeeded}";
                    if (planksCollected == platformPlanks.Length)
                    {
                        CompleteTask(); // Move on to next task
                    }
                }
            }
            else
            {
                canInteract = false; // Makes sure the player can't interact anymore
            }
        }
    }
    /// <summary>
    /// Respawn the player at a specific target location
    /// This is used when the player touches toxic or falls off the map
    /// It disables the FirstPersonController for a short time to avoid instant collision repeat
    /// </summary>
    /// <param name="target"></param>
    IEnumerator Respawn(Transform target)
    {
        isRespawning = true;
        FirstPersonController controller = GetComponent<FirstPersonController>();
        if (controller != null)
        {
            controller.enabled = false;
        }
        yield return new WaitForSeconds(0.05f); // Give physics time to settle
        transform.position = target.position + Vector3.up * 0.5f; // Add height to avoid clipping into ground
        yield return new WaitForSeconds(0.05f); // Wait again to avoid instant collision repeat
        if (controller != null)
        {
            controller.enabled = true;
        }
        isRespawning = false;
    }
    /// <summary>
    /// Do different things based on what the player touched
    /// Items with damage tag damages the player
    /// Items with boat tag end the game
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        // Check if the player is respawning to avoid multiple collisions
        if (isRespawning) return;
        // Check if the player touched an item with the damage tag
        if (collision.gameObject.CompareTag("Damage"))
        {
            // Check if the player touched a specific item that deals damage
            if (collision.gameObject.name == "DamageWire")
            {
                health -= 10; // Decrease health by 10
                healthText.text = "HEALTH: " + health.ToString(); // Update health UI
                wireSound.Play(); // Play wire sound
            }
            else if (collision.gameObject.name == "Toxic")
            {
                health = 100; // Reset health to 100
                healthText.text = "HEALTH: " + health.ToString(); // Update health UI
                StartCoroutine(Respawn(tpTarget)); // Respawn the player at a location
            }
        }
        // If health is less than or equal to 0, reset health and respawn
        if (health <= 0)
        {
            health = 100; // Reset health to 100
            healthText.text = "HEALTH: " + health.ToString(); // Update health UI
            StartCoroutine(Respawn(tpTarget)); // Respawn the player at a location
        }
        // If the player touched a boat, end the game
        if (collision.gameObject.CompareTag("Boat"))
        {
            GameManager gamemanager = FindObjectOfType<GameManager>(); // Get the GameManager script
            gamemanager.EndGame(); // End the game
            endscoreText.text = "SCORE: " + currentScore; // Update the end score UI
        }
        // If the player touched water, respawn the player at a location
        // This is used when the player falls off the map
        if (collision.gameObject.CompareTag("Water"))
        {
            StartCoroutine(Respawn(tpTarget2)); // Respawn the player at a location
        }
    }
    /// <summary>
    /// Update the task whenever a task is completed
    /// </summary>
    public void CompleteTask()
    {
        currentTaskIndex++; // Increase index

        if (currentTaskIndex < tasks.Length)
        {
            taskText.text = tasks[currentTaskIndex]; // Get the next task
        }
        else
        {
            taskText.text = "All tasks complete!"; // When there are no other tasks left
        }
    }
    /// <summary>
    /// Highlights interactable objects when the player is looking at it
    /// </summary>
    /// <param name="obj"></param>
    void ApplyHighlight(GameObject obj)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>(); // Get renderer components of child objects
        // Check for the number of renderers found
        if (renderers.Length == 0)
        {
            Debug.LogWarning("No renderers found on " + obj.name);
            return;
        }
        originalMaterials.Clear(); // Store each renderer’s original material
        // Loop through each renderer and change the material
        foreach (Renderer rend in renderers)
        {
            originalMaterials[rend] = rend.material;
            rend.material = highlightMaterial;
        }
    }
    /// <summary>
    /// Remove the highlights when the player is not looking at the object
    /// </summary>
    void RemoveHighlight()
    {
        if (lastHighlightedObject == null) return; // If nothing is previously highlighted, nothing happens
        Renderer[] renderers = lastHighlightedObject.GetComponentsInChildren<Renderer>(); // Get renderer components of child objects
        // Loop through each renderer and change the material
        foreach (Renderer rend in renderers)
        {
            if (originalMaterials.ContainsKey(rend))
            {
                rend.material = originalMaterials[rend];
            }
        }
        originalMaterials.Clear();
        lastHighlightedObject = null;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // UI texts
        scoreText.text = "SCORE: " + currentScore.ToString();
        healthText.text = "HEALTH: " + health.ToString();
        taskText.text = tasks[currentTaskIndex];
        progressText.text = "0/0";
        // Audios
        wireSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update raycast every frame
        HandleRaycast();
    }
    /// <summary>
    /// Raycast to interact with a singular item at any given time
    /// Checks what the raycast is hitting and change the variables accordingly
    /// Resets the variables frequently to ensure interactions run smoothly
    /// </summary>
    void HandleRaycast()
    {
        // Raycasting
        RaycastHit hit;
        Debug.DrawRay(spawnPoint.position, spawnPoint.forward * interactionDistance, Color.red);

        if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out hit, interactionDistance))
        {
            // Store the item the raycast hits into a GameObject variable
            GameObject hitObject = hit.collider.gameObject;
            // Set canInteract to true if item can be interacted
            canInteract = hitObject.CompareTag("Wire") ||
                              hitObject.CompareTag("Collectible") ||
                              hitObject.CompareTag("Door") ||
                              hitObject.CompareTag("CardA") ||
                              hitObject.CompareTag("CardB") ||
                              hitObject.CompareTag("FuseSlot") ||
                              (hitObject.CompareTag("Fuse") && !hasFuse) ||
                              hitObject.CompareTag("Plank");

            ResetInteraction(); // Reset everything first

            // Check what player hit and update variables accordingly
            if (hitObject.CompareTag("Wire"))
            {
                currentWire = hitObject.GetComponent<WireBehaviour>();
                isWire = true;
                canInteract = true;
            }
            else if (hitObject.CompareTag("Collectible"))
            {
                currentCollectible = hitObject.GetComponent<CollectibleBehaviour>();
                isCollectible = true;
                canInteract = true;
            }
            else if (hitObject.CompareTag("Door"))
            {
                currentDoor = hitObject.GetComponent<DoorBehaviour>();
                canInteract = true;
            }
            else if (hitObject.CompareTag("CardA") || hitObject.CompareTag("CardB"))
            {
                cardObject = hitObject;
                isCard = true;
                canInteract = true;
            }
            else if (hitObject.CompareTag("FuseSlot"))
            {
                currentSlot = hitObject.GetComponent<FuseSlotBehaviour>();
                canInteract = true;
            }
            else if (hitObject.CompareTag("Fuse") && !hasFuse)
            {
                heldFuse = hitObject;
                hasFuse = true;
                hitObject.GetComponent<Renderer>().enabled = false;
                hitObject.GetComponent<Collider>().enabled = false;
                canInteract = false;
            }
            else if (hitObject.CompareTag("Plank"))
            {
                ResetInteraction();

                currentPlank = hit.collider.gameObject;
                isPlank = true;
                canInteract = true;
            }
            // Highlights interactable items
            if (canInteract)
            {
                if (hitObject != lastHighlightedObject)
                {
                    RemoveHighlight();           // Unhighlight previous object
                    ApplyHighlight(hitObject);   // Highlight the new object
                    lastHighlightedObject = hitObject;
                }
            }
            else
            {
                RemoveHighlight();
            }
        }
        else
        {
            RemoveHighlight();
            ResetInteraction();
        }
    }
    /// <summary>
    /// Reset all the variables to ensure that the player is not able to interact when he/she is not supposed to
    /// </summary>
    void ResetInteraction()
    {
        canInteract = false;

        // Reset all interactable flags
        isWire = false;
        isCollectible = false;
        isCard = false;
        isPlank = false;

        // Clear references to interactable objects
        currentWire = null;
        currentCollectible = null;
        currentDoor = null;
        currentSlot = null;
        cardObject = null;
        currentPlank = null;
    }

}