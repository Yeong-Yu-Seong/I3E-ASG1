using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
public PlayerBehaviour player;
    private bool cardEnabled = false;
    private Renderer rend;
    private Collider col;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player reference not set in CardBehaviour!");
        }

        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();

        // Start hidden
        if (rend != null) rend.enabled = false;
        if (col != null) col.enabled = false;
    }

    void Update()
    {
        if (!cardEnabled && player != null && player.wiresNo == 6)
        {
            EnableCard();
        }
    }

    void EnableCard()
    {
        if (rend != null) rend.enabled = true;
        if (col != null) col.enabled = true;
        cardEnabled = true;
        Debug.Log("6 wires collected, card enabled!");
        player.wiresNo = 0;
    }
}
