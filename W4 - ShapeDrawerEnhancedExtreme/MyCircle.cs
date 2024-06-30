using SplashKitSDK;

namespace DrawingShape
{
    public class MyCircle : Shape
    {
        private int _radius;

        public MyCircle(Color color, float x, float y, int _radius) : base(color)
        {
            X = x;
            Y = y;
            Radius = _radius;
        }

        public MyCircle() : this(Color.Blue, 0, 0, 50)
        {
        }

        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public override void Draw()
        {
            if (Selected) { DrawOutLine(); }
            SplashKit.FillCircle(Color, X, Y, Radius);
        }

        public override void DrawOutLine()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, Radius + 2);
        }

        public override bool IsAt(Point2D pt)
        {
            double a, b;
            a = (double)(pt.X - X);
            b = (double)(pt.Y - Y);
            if (Math.Sqrt(a * a + b * b) <= Radius)
            {
                return true;
            }
            return false;
        }
    }
}



