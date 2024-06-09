using System;
using System.Security.Cryptography.X509Certificates;
using SplashKitSDK;

namespace DrawingShape
{
    public class Program
    {
        public static void Main()
        {

            Drawing myDrawing = new Drawing();
            Window window = new Window("Shape Drawer", 800, 600);

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape myShape = new Shape();
                    myShape.X = (float)SplashKit.MouseX();
                    myShape.Y = (float)SplashKit.MouseY();
                    myDrawing.AddShape(myShape);
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    Point2D mousePos;
                    mousePos.X = SplashKit.MouseX();
                    mousePos.Y = SplashKit.MouseY();

                    myDrawing.SelectedShapesAt(mousePos);
                }

                
                if (SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    Shape myShape = new Shape();
                    var selectedShapes = myDrawing.SelectedShapes;
                    
                    foreach (var shape in selectedShapes)
                    {
                        myDrawing.RemoveShape(shape);
                    }
                }

            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                myDrawing.Background = SplashKit.RandomRGBColor(255);
            }

            myDrawing.Draw();

                SplashKit.RefreshScreen();

            }
            while (!window.CloseRequested);
        }
    }

}