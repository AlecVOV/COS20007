using SplashKitSDK;

namespace DrawingShape
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

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
    }
}
