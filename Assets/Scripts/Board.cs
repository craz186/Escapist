using System.Collections.Generic;
using UnityEngine;

public class Board{

	// 2d array declaration in C#
	private readonly Tile[,] _tiles;
	
	public Board(int length, int height) {
		_tiles = new Tile[length, height];
	}
	
	protected List<Point> GetValidMovesForPiece(Piece piece) {
		var validPieceMoves = piece.GetValidMoves();
		var validPieceAndBoardMoves = new List<Point>();
		foreach (var point in validPieceMoves) {
			Tile t = GetTileAtPoint(point);

			if (t != null && t.AllowsPiece) {
				validPieceAndBoardMoves.Add(point);
			}
		}

		return validPieceAndBoardMoves;
	}

	private Tile GetTileAtPoint(Point p) {
		return _tiles[p.X, p.Y];
	}
}
