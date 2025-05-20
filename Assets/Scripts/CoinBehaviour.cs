using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    [SerializeField]
    public int coinScore = 1;
    public void CollectCoin(PlayerBehaviour player){
        player.ModifyScore(coinScore);
        Destroy(gameObject);
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
