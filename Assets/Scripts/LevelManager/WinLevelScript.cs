using UnityEngine;

public class WinLevelScript : MonoBehaviour
{
    [SerializeField] private GameObject[] slots;

    private bool playerHasWon = false;

    /// <summary>
    /// Check if player has completed the level
    /// </summary>
    public void CheckWinState()
    {
        // Check if all slots are full
        bool won = true;
        foreach (GameObject slot in slots)
        {
            if (!slot.GetComponent<SlotScript>().IsSlotFull())
            {
                won = false;
                break;
            }
        }
        playerHasWon = won;
        if (playerHasWon) Debug.Log("You won!");
    }
}
