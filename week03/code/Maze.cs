using System;
using System.Collections.Generic;

/// <summary>
/// Defines a maze using a dictionary. The dictionary contains:
/// (x,y) : [left, right, up, down]
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check to see if you can move left.
    /// </summary>
    public void MoveLeft()
    {
        // Index 0 is Left
        if (_mazeMap[(_currX, _currY)][0])
        {
            _currX -= 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move right.
    /// </summary>
    public void MoveRight()
    {
        // Index 1 is Right
        if (_mazeMap[(_currX, _currY)][1])
        {
            _currX += 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move up.
    /// </summary>
    public void MoveUp()
    {
        // Index 2 is Up.
        if (_mazeMap[(_currX, _currY)][2])
        {
            _currY -= 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move down.
    /// </summary>
    public void MoveDown()
    {
        // Index 3 is Down.
        if (_mazeMap[(_currX, _currY)][3])
        {
            _currY += 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
