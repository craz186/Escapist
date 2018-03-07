namespace piece {
    /**
     * A dog will move 3 spaces towards you in a straight line every turn
     * It will have quick reflexes that allow it to turn directly toward the user for free on the beginning turn
     *
     *
     * -1, 1  0, 1  1, 1
     * -1, 0  0, 0  1, 0 
     * -1,-1  0,-1  1,-1
     *
     * Pattern is one coordinate will always be 0 and other must be within MovementSpeed distance
     *
     * 
     */
    public class Dog : Piece {
        private readonly Move[] _validMoves = {
            new Move(Direction.Up, 3),
            new Move(Direction.Down, 3),
            new Move(Direction.Left, 3),
            new Move(Direction.Right, 3)
        };
        
        public Dog(int x, int y) : base(x, y, PieceType.Dog) {}

        public override Move[] GetMoves() {
            return _validMoves;
        }
    }
}