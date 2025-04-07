using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwitchWorldScript : MonoBehaviour
{
    // Properties
    [SerializeField] private LayerMask wallLayerMask;
    [SerializeField] private GameObject levelManager;
    [SerializeField] private Camera mainCamera;

    /// <summary>
    /// Player switches between the yin and yang worlds
    /// </summary>
    /// <param name="context">Player's input</param>
    public void Switch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            levelManager.GetComponent<WinLevelScript>().SwitchWorlds();
            // If player collides with a wall, switch back to original world
            if (Physics2D.OverlapBox(transform.position, transform.localScale * 0.9f, 0f, wallLayerMask))
            {
                levelManager.GetComponent<WinLevelScript>().SwitchWorlds();
                mainCamera.GetComponent<CameraShakeScript>().StartShake();
            }
        }
    }
}
