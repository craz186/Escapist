using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager {
    // The current enemy pieces
    private readonly Piece[,] _aiPieces;

    private readonly Piece _opponent;

    // current board
    private Board _board;

    private const int MaxSearchDepth = 4;

    public AIManager(Piece[,] aiPieces, Piece piece, Board board) {
        _aiPieces = aiPieces;
        _board = board;
        _opponent = piece;
    }

    void MoveAllAIPieces() {
        // First get our pieces
        // Then for each piece make every possible move.
        // Score each move and save our best move. 
        foreach (var aiPiece in _aiPieces) {
            // needs to recursively call the next part in a function
            var bestAvailableMove = MiniMax(aiPiece, _opponent, 0, true);
            aiPiece.TakeMove(bestAvailableMove);
        }
    }

    private Move MiniMax(Piece currentPiece, Piece opponentPiece, int currentDepth, bool takeMax) {
        Move bestMove = null;
        foreach (var move in currentPiece.GetValidMoves()) {
            var previousLocation = new Point(currentPiece.X, currentPiece.Y);
            currentPiece.TakeMove(move);
            var afterLocation = new Point(currentPiece.X, currentPiece.Y);
            int currentScore;
            
            if (currentDepth < MaxSearchDepth) {
                // If we have not reached our MaxSearchDepth then keep branching
                currentScore = MiniMax(opponentPiece, currentPiece, currentDepth + 1, !takeMax).Score;
            }
            else {
                // We only want to evaluate leaf nodes 
                currentScore = ScoreMove(previousLocation, afterLocation, opponentPiece);
            }

            currentPiece.TakeMove(move.Reverse());
            if (bestMove == null || (takeMax ? currentScore > bestMove.Score : currentScore < bestMove.Score)) {
                move.Score = currentScore;
                bestMove = move;
                
            }
        }

        return bestMove;
    }

    /**
     * A move is scored best for us if we take the opponent
     * A move is scored good for getting closer to the opponent
     * A move is scored bad if we were last in that location
     * A move is scored worst if we get taken
     *
     * Will need opponent parameter to determine who we are scoring
     */
    private int ScoreMove(Point beforePoint, Point afterPoint, Piece opponentPiece) {

        // calculate distance from before point to opponent
        // calculate distance from after point to opponent
        // score is negative for further away and possitive for closer.
        // score is best if distance is 0.

        var beforeDistance = CalculateDistanceBetweenTwoPoints(beforePoint, opponentPiece); // 8
        var afterDistance = CalculateDistanceBetweenTwoPoints(afterPoint, opponentPiece); // 2
        int score;

        if (afterDistance == 0) {
            score = 100;
        } else if (afterDistance < beforeDistance) {
            score = 10;
        } else {
            score = -10;
        }
        
        return score;
    }

    private static int CalculateDistanceBetweenTwoPoints(Point first, Point second) {
        return (int) (Math.Pow(second.X - first.X, 2) + Math.Pow(second.Y - first.Y, 2));
    }
}
