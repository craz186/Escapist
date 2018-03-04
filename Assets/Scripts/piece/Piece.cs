using System;
using System.Collections.Generic;
using piece;

public abstract class Piece : Point {
    private PieceType _pieceType;

    protected Piece(int x, int y, PieceType pieceType) : base(x, y) {
        _pieceType = pieceType;
    }

//  TODO revisit could be useful
//     protected internal IEnumerable<Point> GetValidMoves() {
//        var validMoves = new List<Point>();
//        for (var x = -_movementDistance; x < _movementDistance; x++) {
//            for (var y = -_movementDistance; y < _movementDistance; y++) {
//                var currentX = X + x;
//                var currentY = Y + y;
//                
//                if (IsValidMove(currentX, currentY)) {
//                    validMoves.Add(new Point(currentX, currentY));
//                }
//            }
//        }
//
//        return validMoves;
//    }

    public abstract Move[] GetValidMoves();

    protected internal void TakeMove(Move move) {
        var direction = move.GetDirection();
        var distance = move.GetDistance();

        switch (direction) {
            case Direction.Up:
                Y -= distance;
                break;
            case Direction.Down:
                Y += distance;    
                break;
            case Direction.Right:
                X += distance;
                break;
            case Direction.Left:
                X -= distance;
                break;
        }
        
    }

    public override string ToString() {
        return "(" + X + "," + Y + ")";
    }
//
//    protected abstract bool IsValidMove(int x, int y);
}
