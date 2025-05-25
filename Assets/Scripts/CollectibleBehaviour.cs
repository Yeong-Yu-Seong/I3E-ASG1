using UnityEngine;

public class CollectibleBehaviour : MonoBehaviour
{
    [SerializeField]
    public int collectibleScore = 1;
    public void CollectCollectible(PlayerBehaviour player){
        player.ModifyScore(collectibleScore);
        Destroy(gameObject);
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
