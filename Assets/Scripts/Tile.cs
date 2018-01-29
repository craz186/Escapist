public class Tile : Point {
    
    private readonly bool _allowsPiece = true;
    
    public Tile(int x, int y) : base(x, y) {}
    
    public bool AllowsPiece {
        get { return _allowsPiece; }
    }
}
