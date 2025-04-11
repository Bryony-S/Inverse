using UnityEngine;

public class PushBallScript : PushObjectScript
{
    private Direction currentDirection;

    // Methods
    protected override void Update()
    {
        // Object is currently moving
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * movementSpeed);
            if ((Vector2)transform.position == destination)
            {
                // Check if object should keep moving
                Vector2 newDirection = DirectionToVector2Converter.ConvertTo(currentDirection);
                if (!isSlotted && (!Physics2D.Raycast(transform.position, newDirection, 1f, wallLayerMask)))
                {
                    destination = (Vector2)transform.position + newDirection;
                } // Hit a wall or slot
                else { isMoving = false; }
            }  
        }
    }

    /// <summary>
    /// Object is pushed
    /// </summary>
    /// <param name="directionToPush">The direction of the push</param>
    public override void Push(Direction directionToPush)
    {
        currentDirection = directionToPush;
        base.Push(directionToPush);
    }
}
