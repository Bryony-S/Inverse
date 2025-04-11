using UnityEngine;

public class SlotScript : MonoBehaviour
{
    // Properties
    [SerializeField] private GameObject levelManager;
    [SerializeField] private AudioClip slotClickSFX;
    [SerializeField] private PushableType slotType;

    private bool isSlotFull = false;

    // Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check collision is with pushable object
        if ((collision.gameObject.tag == "Pushable") && !isSlotFull)
        {
            PushObjectScript pushObjectScript = collision.gameObject.GetComponent<PushObjectScript>();
            if ((pushObjectScript != null) && (pushObjectScript.GetPushableType() == slotType))
            {
                // Object is now locked into slot
                isSlotFull = true;
                AudioManagerScript.Instance.PlaySound(slotClickSFX);
                pushObjectScript.isSlotted = true;
                levelManager.GetComponent<WinLevelScript>().CheckWinState();
            }
        }
    }

    public bool IsSlotFull()
    {
        return isSlotFull;
    }
}
