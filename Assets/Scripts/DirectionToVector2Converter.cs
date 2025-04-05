using UnityEngine;

public static class DirectionToVector2Converter
{
    /// <summary>
    /// Converts Direction enum value to a Vector2
    /// </summary>
    /// <param name="dir">The Direction value to convert</param>
    /// <returns>The corresponding Vector2</returns>
    public static Vector2 ConvertTo(Direction dir)
    {
        switch (dir)
        {
            case Direction.Left:
                return Vector2.left;
            case Direction.Right:
                return Vector2.right;
            case Direction.Up:
                return Vector2.up;
            case Direction.Down:
                return Vector2.down;
        }
        return Vector2.zero;
    }

    /// <summary>
    /// Converts Vector2 to a Direction enum value
    /// </summary>
    /// <param name="vector">The Vector2 to convert</param>
    /// <returns>The corresponding Direction value</returns>
    public static Direction ConvertBack(Vector2 vector)
    {
        if (vector == Vector2.left) return Direction.Left;
        if (vector == Vector2.right) return Direction.Right;
        if (vector == Vector2.up) return Direction.Up;
        if (vector == Vector2.down) return Direction.Down;
        return Direction.None;
    }
}
