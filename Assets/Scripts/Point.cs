public class Point {
        
        private readonly int _x;
        private readonly int _y;

        public Point(int x, int y) {
                this._x = x;
                this._y = y;
        }

        public int X {
                get { return _x; }
        }

        public int Y {
                get { return _y; }
        }
}