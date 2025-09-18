/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    // Dictionary that holds maze structure:
    // Key: (x,y) coordinate
    // Value: array of 4 bools → [left, right, up, down]
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;

    // Current position in the maze (starting at (1,1) by default)
    private int _currX = 1;
    private int _currY = 1;

    /// <summary>
    /// Constructor that takes in a dictionary to define the maze layout.
    /// </summary>
    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Attempt to move left from the current position.
    /// If blocked, throw an exception. If allowed, update _currX.
    /// </summary>
    public void MoveLeft()
    {
        var key = (_currX, _currY);
        if (!_mazeMap[key][0]) // index 0 → left
            throw new InvalidOperationException("Can't go that way!");
        _currX--; // move left decreases X
    }

    /// <summary>
    /// Attempt to move right from the current position.
    /// If blocked, throw an exception. If allowed, update _currX.
    /// </summary>
    public void MoveRight()
    {
        var key = (_currX, _currY);
        if (!_mazeMap[key][1]) // index 1 → right
            throw new InvalidOperationException("Can't go that way!");
        _currX++; // move right increases X
    }

    /// <summary>
    /// Attempt to move up from the current position.
    /// If blocked, throw an exception. If allowed, update _currY.
    /// </summary>
    public void MoveUp()
    {
        var key = (_currX, _currY);
        if (!_mazeMap[key][2]) // index 2 → up
            throw new InvalidOperationException("Can't go that way!");
        _currY--; // move up decreases Y
    }

    /// <summary>
    /// Attempt to move down from the current position.
    /// If blocked, throw an exception. If allowed, update _currY.
    /// </summary>
    public void MoveDown()
    {
        var key = (_currX, _currY);
        if (!_mazeMap[key][3]) // index 3 → down
            throw new InvalidOperationException("Can't go that way!");
        _currY++; // move down increases Y
    }

    /// <summary>
    /// Get the current status of the player in the maze.
    /// Returns the current coordinates (x,y).
    /// </summary>
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}