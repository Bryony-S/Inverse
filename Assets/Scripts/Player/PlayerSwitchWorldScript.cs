using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwitchWorldScript : MonoBehaviour
{
    // Properties
    [SerializeField] private GameObject yinWorldManager;
    [SerializeField] private GameObject yangWorldManager;

    /// <summary>
    /// Player switches between the yin and yang worlds
    /// </summary>
    /// <param name="context">Player's input</param>
    public void SwitchWorld(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            yinWorldManager.SetActive(!yinWorldManager.activeSelf);
            yangWorldManager.SetActive(!yangWorldManager.activeSelf);
        }
    }
}
