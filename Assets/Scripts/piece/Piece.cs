using System;
using System.Collections.Generic;
using piece;

public abstract class Piece : Point {
    private PieceType _pieceType;
    private readonly int _movementDistance;

    protected Piece(int x, int y, PieceType pieceType, int movementDistance) : base(x, y) {
        this._pieceType = pieceType;
        this._movementDistance = movementDistance;
    }

    protected internal IEnumerable<Point> GetValidMoves() {
        var validMoves = new List<Point>();
        for (var x = -_movementDistance; x < _movementDistance; x++) {
            for (var y = -_movementDistance; y < _movementDistance; y++) {
                var currentX = X + x;
                var currentY = Y + y;
                
                if (IsValidMove(currentX, currentY)) {
                    validMoves.Add(new Point(currentX, currentY));
                }
            }
        }

        return validMoves;
    }

    protected abstract bool IsValidMove(int x, int y);
}
