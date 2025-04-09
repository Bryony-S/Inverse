using UnityEngine;

public class SlotScript : MonoBehaviour
{
    // Properties
    [SerializeField] private GameObject levelManager;
    [SerializeField] private AudioClip slotClickSFX;

    private bool isSlotFull = false;

    // Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check collision is with pushable object
        if ((collision.gameObject.tag == "Pushable") && !isSlotFull)
        {
            // Object is now locked into slot
            isSlotFull = true;
            AudioManagerScript.Instance.PlaySound(slotClickSFX);
            collision.gameObject.GetComponent<PushObjectScript>().isSlotted = true;
            levelManager.GetComponent<WinLevelScript>().CheckWinState();
        }
    }

    public bool IsSlotFull()
    {
        return isSlotFull;
    }
}
