using UnityEngine;

public class SlotScript : MonoBehaviour
{
    private bool isSlotFull = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check collision is with pushable object
        if ((collision.gameObject.tag == "Pushable") && !isSlotFull)
        {
            // Object is now locked into slot
            isSlotFull = true;
            collision.gameObject.GetComponent<PushObjectScript>().isSlotted = true;
        }
    }
}
