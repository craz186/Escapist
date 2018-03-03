using System.Collections.Generic;
using UnityEngine;

public class Board{

	// 2d array declaration in C#
	private readonly Tile[,] _tiles;
	
	public Board(int length, int height) {
		_tiles = new Tile[length, height];
	}
}
