using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPushScript : MonoBehaviour
{
    // Properties
    [SerializeField] private LayerMask wallLayerMask;
    [SerializeField] private DirectionVariable playerDirection;

    /// <summary>
    /// Player attempts to push an object
    /// </summary>
    /// <param name="context">Player's input</param>
    public void PushObject(InputAction.CallbackContext context)
    {
        if (context.performed && (playerDirection.value != Direction.None))
        {
            var hit = Physics2D.Raycast(transform.position, DirectionToVector2Converter.ConvertTo(playerDirection.value), 1f, wallLayerMask);
            if (hit)
            {
                // If object is pushable, run it's push method
                if (hit.collider.tag == "Pushable") hit.collider.gameObject.GetComponent<PushObjectScript>().Push(playerDirection.value);
            }
        }
    }
}
