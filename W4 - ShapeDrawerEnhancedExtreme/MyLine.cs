﻿using SplashKitSDK;

namespace DrawingShape
{
    public class MyLine : Shape
    {
        private float _endX;
        private float _endY;
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

        public MyLine() : this(Color.Green)
        {
        }

        public MyLine(Color color) : base(color)
        {
            Color = color;
            EndX = 700;
            EndY = 200;
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutLine();
            }
            SplashKit.DrawLine(Color, X, Y, _endX, _endY);
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
    }
}