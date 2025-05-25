using UnityEngine;

public class BoxZoneBehaviour : MonoBehaviour
{
    private int boxesInside = 0;  // count how many boxes are inside

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            boxesInside++;
            CheckBoxes();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            boxesInside--;
        }
    }

    void CheckBoxes()
    {
        if (boxesInside == 3)
        {
            GameObject card = GameObject.FindWithTag("CardA");
            if (card != null)
            {
                Renderer rend = card.GetComponent<Renderer>();
                if (rend != null) rend.enabled = true;

                Collider col = card.GetComponent<Collider>();
                if (col != null) col.enabled = true;

                Debug.Log("3 boxes in trigger, card enabled!");
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
