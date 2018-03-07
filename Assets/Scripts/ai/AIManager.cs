using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager {
    // The current enemy pieces
    private readonly List<Piece> _aiPieces;

    private const int MaxSearchDepth = 8;

    public AIManager(List<Piece> aiPieces) {
        _aiPieces = aiPieces;
    }

    public void MoveAllAiPieces(Board board, Piece opponent) {
        // First get our pieces
        // Then for each piece make every possible move.
        // Score each move and save our best move. 
        var boardCopy = board;
        foreach (var aiPiece in _aiPieces) {
            // needs to recursively call the next part in a function
            var bestAvailableMove = MiniMax(boardCopy, aiPiece, opponent, 0);
            board.MovePiece(aiPiece, bestAvailableMove, false);
        }
    }

    private Move MiniMax(Board board, Piece currentPiece, Piece opponentPiece, int currentDepth) {
        Move bestMove = null;
        foreach (var move in currentPiece.GetMoves()) {
            var previousLocation = new Point(currentPiece.X, currentPiece.Y);
            var moveResult = board.MovePiece(currentPiece, move, true);
            var currentScore = currentPiece.IsUserPiece ? 100000 : -100000;
            switch (moveResult) {
                case MoveResult.InvalidMove:
                    continue;
                // This case can only be triggered by an AI
                case MoveResult.UserPieceTaken:
                    move.Score = -currentScore;
                    bestMove = move;
                    continue;
                // This case could be triggered by an AI
                case MoveResult.AiPieceTaken:
                    if (currentPiece.IsUserPiece) {
                        move.Score = -currentScore;
                        bestMove = move;
                    }
                    continue;
                case MoveResult.ValidMove:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            if (currentDepth < MaxSearchDepth) {
                // If we have not reached our MaxSearchDepth then keep branching
                var currentMove= MiniMax(board, opponentPiece, currentPiece, currentDepth + 1);
                if (currentMove != null) {
                    currentScore = currentMove.Score;
                }
            } else {
                // We only want to evaluate leaf nodes 
                currentPiece.TakeMove(move);
                var afterLocation = new Point(currentPiece.X, currentPiece.Y);
                currentPiece.TakeMove(move.Reverse());
                currentScore = ScoreMove(previousLocation, afterLocation, opponentPiece);
            }

            if (bestMove == null || (currentPiece.IsUserPiece ? currentScore < bestMove.Score : currentScore > bestMove.Score)) {
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
        // score is negative for further away and positive for closer.
        // score is best if distance is 0.

        var beforeDistance = CalculateDistanceBetweenTwoPoints(beforePoint, opponentPiece); // 8
        var afterDistance = CalculateDistanceBetweenTwoPoints(afterPoint, opponentPiece); // 2
        int score;

        if (afterDistance == 0) {
            score = 100;
        }
        else {
            score = beforeDistance - afterDistance;
        }
        
        return score;
    }

    private static int CalculateDistanceBetweenTwoPoints(Point first, Point second) {
        return (int) (Math.Pow(second.X - first.X, 2) + Math.Pow(second.Y - first.Y, 2));
    }

    public List<Piece> GetAiPieces() {
        return _aiPieces;
    }

    public void RemovePiece(Piece pieceToBeTaken) {
        _aiPieces.Remove(pieceToBeTaken);
    }
}
