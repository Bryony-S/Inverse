using UnityEngine;

public class PushObjectScript : MonoBehaviour
{
    // Properties
    [SerializeField] private LayerMask wallLayerMask;
    [SerializeField] private float movementSpeed;

    private Vector2 destination;
    private bool isMoving = false;
    [HideInInspector] public bool isSlotted = false;

    #region METHODS
    private void Start()
    {
        destination = transform.position;
    }

    private void Update()
    {
        // Object is currently moving
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * movementSpeed);
            if ((Vector2)transform.position == destination) isMoving = false;
        }
    }

    /// <summary>
    /// Object is pushed to a new space
    /// </summary>
    /// <param name="directionToPush">The direction of the push</param>
    public void Push(Direction directionToPush)
    {
        // Check object is not already moving
        if (!isMoving && !isSlotted)
        {
            Vector2 newDirection = DirectionToVector2Converter.ConvertTo(directionToPush);
            // If new destination is not blocked by a wall, move towards new destination
            if (!Physics2D.Raycast(transform.position, newDirection, 1f, wallLayerMask)) destination = (Vector2)transform.position + newDirection;
            isMoving = true;
        }
    }
    #endregion
}
