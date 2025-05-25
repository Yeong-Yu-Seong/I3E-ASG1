using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    int currentScore = 0;
    GameObject coinObject;
    CollectibleBehaviour currentCollectible;
    WireBehaviour currentWire;
    public int wiresNo = 0;
    bool isWire = false;
    bool isCoin = false;
    bool isCollectible = false;
    bool canInteract = false;
    FuseSlotBehaviour currentSlot;
    DoorBehaviour currentDoor;
    CoinBehaviour currentCoin;
    GameObject cardObject;
    bool isCard = false;
    GameObject heldFuse;
    bool hasFuse = false;
    int planksNeeded = 3;
    int planksCollected = 0;
    public GameObject[] platformPlanks;
    [SerializeField]
    int health = 100;
    public void ModifyScore(int amount){
        currentScore += amount;
        Debug.Log("Score: "+currentScore);
    }
    public void WireCount(int amount) {
        wiresNo += amount;
        Debug.Log("Wire count: " + wiresNo);
    }
    void OnInteract(){
        if (canInteract)
        {
            if (isCoin)
            {
                Debug.Log("Interacting with object");
                // Get the currentCoin to interact
                currentCoin.CollectCoin(this);
                isCoin = false;
                currentCoin = null;
            }
            else if (isCard == false && currentDoor)
            {
                Debug.Log("Door locked.");
            }
            else if (isCard == true && currentDoor)
            {
                currentDoor.Interact();
                isCard = false;
                cardObject = null;
            }
            else if (isCollectible)
            {
                Debug.Log("Collecting...");
                currentCollectible.CollectCollectible(this);
                isCollectible = false;
                currentCollectible = null;
            }
            else if (isWire)
            {
                Debug.Log("Collecting...");
                currentWire.CollectWire(this);
                isWire = false;
                currentWire = null;
            }
            else if (hasFuse && currentSlot != null)
            {
                currentSlot.InsertFuse(heldFuse);
                hasFuse = false;
                heldFuse = null;
            }
        }
        else
        {
            canInteract = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            isCoin = false;
            currentCoin = null;
        }
        else if (other.gameObject.CompareTag("Door"))
        {
            currentDoor = null;
        }
        else if (other.gameObject.CompareTag("CardA"))
        {
            isCard = false;
            cardObject = null;
        }else if (other.gameObject.CompareTag("CardB"))
        {
            isCard = false;
            cardObject = null;
        }
        else if (other.gameObject.CompareTag("Collectible"))
        {
            isCollectible = false;
            currentCollectible = null;
        }
        else if (other.gameObject.CompareTag("Wire"))
        {
            isWire = false;
            currentWire = null;
        }

        canInteract = false;
    }
    void OnTriggerEnter(Collider other){
        Debug.Log(other.gameObject.name + " entered the trigger.");
        if (other.gameObject.CompareTag("Coin"))
        {
            // If the object is coin, I can interact with it
            Debug.Log("Collectible object dectected.");
            isCoin = true;
            // Store the CoinBehaviour into currentCoin
            currentCoin = other.gameObject.GetComponent<CoinBehaviour>();
            canInteract = true;

        }
        else if (other.gameObject.CompareTag("Door"))
        {
            canInteract = true;
            currentDoor = other.gameObject.GetComponent<DoorBehaviour>();

        }
        else if (other.gameObject.CompareTag("CardA"))
        {
            canInteract = true;
            isCard = true;
            cardObject = other.gameObject;
            cardObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("CardB"))
        {
            canInteract = true;
            isCard = true;
            cardObject = other.gameObject;
            cardObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Collectible"))
        {
            // If the object is collectible, I can interact with it
            Debug.Log("Collectible object dectected.");
            isCollectible = true;
            // Store the CollectibleBehaviour into currentCollectible
            currentCollectible = other.gameObject.GetComponent<CollectibleBehaviour>();
            canInteract = true;

        }
        else if (other.gameObject.CompareTag("Wire"))
        {
            Debug.Log("Wire detected.");
            currentWire = other.gameObject.GetComponent<WireBehaviour>();
            canInteract = true;
            isWire = true;
        }
        else if (other.CompareTag("Fuse") && !hasFuse)
        {
            heldFuse = other.gameObject;
            hasFuse = true;
            other.GetComponent<Renderer>().enabled = false;
            other.GetComponent<Collider>().enabled = false;
            Debug.Log("Picked up Fuse: " + heldFuse.GetComponent<FuseBehaviour>().fuseID);
        }
        else if (other.CompareTag("FuseSlot"))
        {
            currentSlot = other.GetComponent<FuseSlotBehaviour>();
            canInteract = true;
            Debug.Log("Interacting with fuse slot " + currentSlot.correctFuseID);
        }
        else if (other.CompareTag("Plank"))
        {

            planksCollected++;
            Destroy(other.gameObject); // Remove collected plank

            Debug.Log("Plank collected: " + planksCollected);

            if (planksCollected <= platformPlanks.Length)
            {
                platformPlanks[planksCollected - 1].SetActive(true); // Activate one plank
            }
        }
        else if (other.CompareTag("Boat"))
        {
            Debug.Log("WIN");
        }
        else
        {
            canInteract = false;
        }
    }
    /*void OnTriggerStay (Collider other){
        if (other.gameObject.CompareTag("Heal")){
            if (health==100){
                Debug.Log("Max health.");
            } else {
                health++;
                Debug.Log("Health: "+health);
            }
        } else if (other.gameObject.CompareTag("Damage")){
            if (health<1){
                health--;
                Debug.Log("Health: "+health);
            } else {
                Debug.Log("You died.");
            }
        }
    }*/
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Damage"))
        {
                Debug.Log("Damaged!");
            if (collision.gameObject.name == "DamageWire")
            {
                health -= 10;
                Debug.Log("Health: " + health);
            }
            else if (collision.gameObject.name == "Toxic")
            {
                health -= 100;
                Debug.Log("Dead.");
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
