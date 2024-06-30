using SplashKitSDK;

namespace DrawingShape
{
    public abstract class Shape
    {
        private Color _color;
        private float _x, _y;
        private bool _selected;

        public Shape(Color color)
        {
            _color = color;
        }

        public Shape() : this(Color.Green) { }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X
        {
            get {return _x;}
            set { _x = value; }
        }

        public float Y
        {
            get { return _y;}
            set { _y = value; }
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public abstract void Draw();

        public abstract void DrawOutLine();

        public abstract bool IsAt(Point2D pt);

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteColor(_color);
            writer.WriteLine(_x);
            writer.WriteLine(_y);
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            Color = reader.ReadColor();
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }


    }
}