using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwitchWorldScript : MonoBehaviour
{
    // Properties
    [SerializeField] private GameObject yinWorldManager;
    [SerializeField] private GameObject yangWorldManager;
    [SerializeField] private GameObject invertColourOverlay;
    [SerializeField] private LayerMask wallLayerMask;

    // Methods
    /// <summary>
    /// Player switches between the yin and yang worlds
    /// </summary>
    /// <param name="context">Player's input</param>
    public void Switch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SwitchWorlds();
            // If player collides with a wall, switch back to original world
            if (Physics2D.OverlapBox(transform.position, transform.localScale * 0.9f, 0f, wallLayerMask)) SwitchWorlds();
        }
    }

    /// <summary>
    /// Switch player between worlds
    /// </summary>
    private void SwitchWorlds()
    {
        yinWorldManager.SetActive(!yinWorldManager.activeSelf);
        yangWorldManager.SetActive(!yangWorldManager.activeSelf);
        invertColourOverlay.SetActive(!invertColourOverlay.activeSelf);
    }
}
