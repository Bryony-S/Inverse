using UnityEngine;

public class SlotScript : MonoBehaviour
{
    [SerializeField] private GameObject levelManager;

    private bool isSlotFull = false;

    // Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check collision is with pushable object
        if ((collision.gameObject.tag == "Pushable") && !isSlotFull)
        {
            // Object is now locked into slot
            isSlotFull = true;
            collision.gameObject.GetComponent<PushObjectScript>().isSlotted = true;
            levelManager.GetComponent<WinLevelScript>().CheckWinState();
        }
    }

    public bool IsSlotFull()
    {
        return isSlotFull;
    }
}
