using UnityEngine;

public class PowerRoomBehaviour : MonoBehaviour
{
    public FuseSlotBehaviour[] slots;
    public GameObject doorToOpen;
    bool AllFusesCorrect()
    {
        foreach (var slot in slots)
        {
            if (!slot.correct) return false;
        }
        return true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AllFusesCorrect())       // Check if all fuses are correct
        {
            doorToOpen.transform.position = new Vector3(-68.5f,5f,-19f);  // Open the door (or replace with animation)
            Debug.Log("Power restored!");
            this.enabled = false;    // Stop checking every frame
        }
    }
}
