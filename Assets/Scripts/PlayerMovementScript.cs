using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    // Properties
    [SerializeField] private float movementSpeed;
    [SerializeField] private LayerMask wallLayerMask;

    private Vector2 destination;
    private Vector2 currentDirection = Vector2.zero;

    #region METHODS
    private void Start()
    {
        destination = transform.position;
    }

    private void Update()
    {
        // Player movement
        if ((Vector2)transform.position != destination)
        {
            // Player moves towards destination
            transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * movementSpeed);
        }
        else if ((currentDirection != Vector2.zero) && (!Physics2D.Raycast(transform.position, currentDirection, 1f, wallLayerMask)))
        {
            // Set new destination if current direction is not zero and does not collide with a wall
            destination += currentDirection;
        }

    }

    /// <summary>
    /// Player moves
    /// </summary>
    /// <param name="context">Player's input</param>
    public void Movement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentDirection = context.ReadValue<Vector2>();
            if (currentDirection.x != 0f) currentDirection.y = 0f; // Stops diagonal movement and prioritises horizontal movement over vertical
        }
        else if (context.canceled) { currentDirection = Vector2.zero; }
    }
    #endregion
}
