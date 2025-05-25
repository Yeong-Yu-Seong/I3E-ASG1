using UnityEngine;

public class WireBehaviour : MonoBehaviour
{
    int wireCount = 1;
    public void CollectWire(PlayerBehaviour player){
        player.WireCount(wireCount);
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
