using System;
using System.Collections.Generic;
using piece;
using UnityEngine;

public class Board{

	// 2d array declaration in C#
	private readonly Tile[,] _tiles;
	private Piece _userPiece;
	private AIManager _aiManager;
	private int _xLength = 0;
	private int _yLength = 0;
	
	public Board(Tile[,] tiles, Piece userPiece, AIManager aiManager, int xLength, int yLength) {
		_tiles = tiles;
		_userPiece = userPiece;
		_aiManager = aiManager;
		_xLength = xLength;
		_yLength = yLength;

	}

	public static Board CreateBoardFromFile(string path) {
		var lines = System.IO.File.ReadAllLines(path);
		Tile[,] tiles = null;
		Piece userPiece = null;
		var aiPieces = new List<Piece>();
		var xLength = 1;
		var yLength = 1;
		// read in each lines and parse into Tiles and Pieces
		for(var y = 0; y < lines.Length; y++) {
			var line = lines[y];
			// 'D' is for Dog
			// A 'U' infront of a letter will indicate that this is a users piece
			var characters = line.Split(',');
			if (tiles == null) {
				tiles = new Tile[characters.Length, lines.Length];
			}

			xLength = characters.Length;
			yLength = lines.Length;
			for (var x = 0; x < xLength; x++) {
				var character = characters[x];
				// TODO here we can change tile type in future 
				var tile = new Tile(x, y);
				tiles.SetValue(tile, x, y);
				if (character.StartsWith("U")) {
					userPiece = new Dog(x, y);
				} else if (character.Equals("D")) {
					aiPieces.Add(new Dog(x, y));
		  		}
			}
		}
		var aiManager = new AIManager(aiPieces);
		return new Board(tiles, userPiece, aiManager, xLength, yLength);
	}

	public void Print() {
		Console.WriteLine("XLength: " + _xLength + ", YLength: " + _yLength);
		Console.WriteLine("UserPiece :" + _userPiece);
		foreach (var aiPiece in _aiManager.GetAiPieces()) {
			Console.WriteLine("AIPiece :" + aiPiece);
		}
		for(var x = 0; x < _xLength; x++) {
			for(var y = 0; y < _yLength; y++) {
				var tile = _tiles.GetValue(x,y);
				Console.Write(tile + " ");
			}	
			Console.WriteLine();
		}
		
	}
}
