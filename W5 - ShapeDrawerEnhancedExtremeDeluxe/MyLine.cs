using SplashKitSDK;

namespace DrawingShape
{
    public class MyLine : Shape
    {
        private float _endX, _endY;
        private int CircleRadius = 10;

        public float EndX
        {
            get { return _endX; }
            set { _endX = value; }
        }

        public float EndY
        {
            get { return _endY; }
            set { _endY = value; }
        }

        public MyLine() : this(Color.Green) { }

        public MyLine(Color color) : base(color)
        {
            EndX = 700;
            EndY = 200;
        }

        public override void Draw()
        {
            if (Selected) { DrawOutLine(); }
            SplashKit.DrawLine(Color, X, Y, EndX, EndY);
        }

        public override void DrawOutLine()
        {
            Color outlineColor = Color.Black;
            SplashKit.DrawCircle(outlineColor, X, Y, CircleRadius);
            SplashKit.DrawCircle(outlineColor, EndX, EndY, CircleRadius);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, EndX, EndY));
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(EndX);
            writer.WriteLine(EndY);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            EndX = reader.ReadInteger();
            EndY = reader.ReadInteger();
        }
    }
}
