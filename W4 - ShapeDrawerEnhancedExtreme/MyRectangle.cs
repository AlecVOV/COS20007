using SplashKitSDK;

namespace DrawingShape
{
    public class MyRectangle : Shape
    {
        private int _width, _height;

        public MyRectangle(Color color, float x, float y, int _width, int _height) : base(color)
        {
            X = x;
            Y = y;
            Width = _width;
            Height = _height;
        }
        public MyRectangle() : this(Color.Green, 0, 0, 200, 100) { }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public override void Draw()
        {
            if (Selected) { DrawOutLine(); }
            SplashKit.FillRectangle(Color, X, Y, Width, Height);
        }

        public override void DrawOutLine()
        {
            SplashKit.DrawRectangle(Color.Black, X - 2, Y - 2, Width + 4, Height + 4);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInRectangle(pt, SplashKit.RectangleFrom(X, Y, Width, Height));
        }

    }
}
