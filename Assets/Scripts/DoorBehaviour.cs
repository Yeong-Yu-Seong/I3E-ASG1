using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public void Interact(){
        Vector3 doorRotation = transform.eulerAngles;
        if (gameObject.CompareTag("Door"))
        {
            doorRotation.y -= 90f;
        } else if (gameObject.CompareTag("Door_RTurn")) {
            doorRotation.y += 90f;
        }
        else
        {
            Debug.Log("Error");
        }
        transform.eulerAngles = doorRotation; // Apply the rotation
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
