using System;

public class Move {
    // TODO Finalize Move class, is direction and distance the best measurement? Would previous location to next location make more sense?
    // A Move will have a direction ENum
    // A Move will have a distance
    // Or will Move just have a destination? Or both?
    // How do we handle for multiple moves?
    
    private readonly int _distance;
    private readonly Direction _direction;
    
    public Move(Direction direction, int distance) {
        _direction = direction;
        _distance = distance;
    }
    
    public int Score { get; set; }
    
    public Direction GetDirection() {
        return _direction;
    }
    
    public int GetDistance() {
        return _distance;
    }

    public Move Reverse() {
        var reverseDirection = ((int) _direction + 2) % 4;
        var reverseMove = new Move((Direction) Enum.Parse(typeof(Direction), "" + reverseDirection), _distance);
        return reverseMove;
    }
}

/**
 * Direction enum. The order of the enums is important to allow the reverse method to be super efficient
 */
public enum Direction {
    Up = 0,
    Left = 1,
    Down = 2,
    Right = 3
}