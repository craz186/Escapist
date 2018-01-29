namespace piece {
    public class Dog : Piece {
        private const int MovementSpeed = 3;

        public Dog(int x, int y) : base(x, y, PieceType.Dog, MovementSpeed) {
            
        }

        /*
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
         * TODO SG: Can abstract out to Piece later if this is reuseable
         * 
         */
        protected override bool IsValidMove(int x, int y) {
            var xDiff = x - X;
            var yDiff = y - Y;
            
            if (xDiff <= MovementSpeed && xDiff > -MovementSpeed && yDiff == 0) {
                return true;
            }

            if (yDiff <= MovementSpeed && yDiff > -MovementSpeed && xDiff == 0) {
                return true;
            }

            return false;
        }
    }
}