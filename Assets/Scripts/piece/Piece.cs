﻿using System;
using System.Collections.Generic;
using piece;

public abstract class Piece : Point {
    private PieceType _pieceType;
    private bool _isUserPiece;
    protected Piece(int x, int y, PieceType pieceType) : base(x, y) {
        _pieceType = pieceType;
    }

    public bool IsUserPiece { get; set; } = false;

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

    public abstract Move[] GetMoves();

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

    public Point[] GetAllMoveCoordinatesForMove(Move move) {
        var returnPoints = new Point[move.GetDistance()];
        switch (move.GetDirection()) {
            case Direction.Up:
                returnPoints = GetAllPointsOnPath(move, 0, -1);
                break;
            case Direction.Down:
                returnPoints = GetAllPointsOnPath(move, 0, 1);
                break;
            case Direction.Left:
                returnPoints = GetAllPointsOnPath(move, -1, 0);
                break;
            case Direction.Right:
                returnPoints = GetAllPointsOnPath(move, 1, 0);
                break;
        }

        return returnPoints;
    }

    private Point[] GetAllPointsOnPath(Move move, int xModifier, int yModifier) {
        var returnPoints = new Point[move.GetDistance()];
        for (var i = 0; i < move.GetDistance(); i++) {
            returnPoints[i] = new Point(X + xModifier, Y + yModifier);
        }
        return returnPoints;
    }

    public override string ToString() {
        return "(" + X + "," + Y + ")";
    }
}
