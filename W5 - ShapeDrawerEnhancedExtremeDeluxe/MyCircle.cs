using SplashKitSDK;

namespace DrawingShape
{
    public class MyCircle : Shape
    {
        int _radius;

        public MyCircle(Color color, float x, float y, int radius) : base(color)
        {
            X = x;
            Y = y;
            _radius = radius;
        }

        public MyCircle() : this(Color.Blue, 0, 0, 200)
        {
        }

        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutLine();
            }
            SplashKit.FillCircle(Color, X, Y, 50);
        }

        public override void DrawOutLine()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, 52);
        }

        public override bool IsAt(Point2D pt)
        {
            double a, b;
            a = (double)(pt.X - X);
            b = (double)(pt.Y - Y);
            if (Math.Sqrt(a * a + b * b) <= _radius)
            {
                return true;
            }
            return false;
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(Radius);
        }
        
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }
    }
}



