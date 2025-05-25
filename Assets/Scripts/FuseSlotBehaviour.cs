using UnityEngine;

public class FuseSlotBehaviour : MonoBehaviour
{
    [SerializeField]
    public string correctFuseID;
    public bool correct = false;
    public void InsertFuse(GameObject fuse)
    {
        string fuseID = fuse.GetComponent<FuseBehaviour>().fuseID;
        if (fuseID == correctFuseID)
        {
            correct = true;
            Debug.Log("Correct fuse.");
        }
        else
        {
            Debug.Log("Wrong fuse.");
            Renderer rend = fuse.GetComponent<Renderer>();
            if (rend != null) rend.enabled = true;

            Collider col = fuse.GetComponent<Collider>();
            if (col != null) col.enabled = true;
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
