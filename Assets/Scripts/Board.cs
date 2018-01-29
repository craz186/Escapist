using UnityEngine;

public class Board : MonoBehaviour {

	// 2d array declaration in C#
	Tile[,] tiles;
	public Board(int length, int height) {
		tiles = new Tile[length, height];
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
