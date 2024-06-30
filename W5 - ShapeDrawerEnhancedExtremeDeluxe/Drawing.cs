using SplashKitSDK;
using System.IO;
using System.Reflection.PortableExecutable;

namespace DrawingShape
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;
        StreamWriter writer;
        StreamReader reader;


        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        public Drawing() : this(Color.White) { }

        public List<Shape> SelectedShapes
        {
            get
            {
                var result = new List<Shape>();

                foreach (var s in _shapes)
                {
                    if (s.Selected)
                    {
                        result.Add(s);
                    }
                }
                return result;
            }
        }

        public int ShapeCount
        {
            get { return _shapes.Count(); }
        }

        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
        }

        public void SelectedShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt))
                    s.Selected = !s.Selected;
                else
                    s.Selected = s.Selected;
            }
        }

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        public bool RemoveShape(Shape shape)
        {
            return _shapes.Remove(shape);
        }

        public void Save(string filename)
        {
            try
            {
                writer = new StreamWriter(filename);
                writer.WriteColor(_background);
                writer.WriteLine(ShapeCount);

                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
            finally
            {
                writer.Close();
            }
        }

        public void Load(string filename)
        {
            try
            {
                reader = new StreamReader(filename);
                Shape s;
                string kind;
                _background = reader.ReadColor();
                int count = reader.ReadInteger();
                _shapes.Clear();

                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();
                    switch (kind)
                    {
                        case "Rectangle":
                            s = new MyRectangle();
                            break;
                        case "Circle":
                            s = new MyCircle();
                            break;
                        case "Line":
                            s = new MyLine();
                            break;
                        default:
                            throw new InvalidDataException("Error at shape: " + kind);
                    }
                    s.LoadFrom(reader);
                    AddShape(s);
                }
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
