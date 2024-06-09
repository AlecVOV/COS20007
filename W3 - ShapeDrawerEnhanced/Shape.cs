using System.Dynamic;
using System.Runtime.CompilerServices;
using SplashKitSDK;

namespace DrawingShape
{
    public class Shape
    {
        private Color _color;
        private float _x;
        private float _y;
        private int _width;
        private int _height;
        private bool _selected;

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
        public Shape()
        {
            _color = Color.Green;
            _x = _y = 0f;
            _width = _height = 100;
        }

        public bool Selected
        {
            get 
            {
                return _selected;
            }

            set 
            {
                _selected = value;
            }
        }

        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
            if (Selected)
            {
                DrawOutline();
            }
        }

        public bool IsAt(Point2D p)
        {
            return SplashKit.PointInRectangle(p, SplashKit.RectangleFrom(X, Y, _width, _height));
        }

        public void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, _x - 2, _y - 2, _width + 4, _height + 4);
        }


    }
}