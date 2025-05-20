using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    int currentScore = 0;
    [SerializeField]
    GameObject coinObject;
    bool isCoin = false;
    CoinBehaviour currentCoin;
    [SerializeField]
    int health = 100;
    public void ModifyScore(int amount){
        currentScore += amount;
        Debug.Log("Score: "+currentScore);
    }
    void OnInteract(){
        if (isCoin){
            Debug.Log("Interacting with object");
            // Get the currentCoin to interact
            currentCoin.CollectCoin(this);
            isCoin = false;
            currentCoin = null;
        }
    }
    void OnTriggerEnter(Collider other){
        Debug.Log(other.gameObject.name + " entered the trigger.");
        if (other.gameObject.CompareTag("Coin")){
            // If the object is coin, I can interact with it
            Debug.Log("Collectible object dectected.");
            isCoin = true;
            // Store the CoinBehaviour into currentCoin
            currentCoin = other.gameObject.GetComponent<CoinBehaviour>();
        } else {
            isCoin = false;
        }
    }
    void OnTriggerStay (Collider other){
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
    }
    /*void OnCollisionStay(Collision collision){
        if (collision.gameObject.CompareTag("Heal")){
            if (health==100){
                Debug.Log("Max health.");
            } else {
                health++;
                Debug.Log("Health: "+health);
            }
        } else if (collision.gameObject.CompareTag("Damage")){
            if (health >0){
                health--;
                Debug.Log("Health: "+health);
            } else {
                Debug.Log("You died.");
            }
        } else {
            Debug.Log("Nothing happened.");
        }
    }*/
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
