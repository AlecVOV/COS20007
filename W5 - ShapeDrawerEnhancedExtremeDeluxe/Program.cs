using SplashKitSDK;

namespace DrawingShape
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Rectangle;
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                else if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                Shape newShape = null;
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    if (kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle newRect = new MyRectangle();
                        newShape = newRect;
                    }
                    else if (kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle newCircle = new MyCircle();
                        newShape = newCircle;
                    }
                    else if (kindToAdd == ShapeKind.Line)
                    {
                        newShape = new MyLine();
                    }
                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();
                    myDrawing.AddShape(newShape);
                }

                // Select the shape
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    Point2D mousePos;
                    mousePos.X = SplashKit.MouseX();
                    mousePos.Y = SplashKit.MouseY();
                    myDrawing.SelectedShapesAt(mousePos);
                }

                // Choose the shape to delete
                if (SplashKit.KeyTyped(KeyCode.BackspaceKey) || SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    var selectedShapes = myDrawing.SelectedShapes;

                    foreach (var shape in selectedShapes)
                    {
                        myDrawing.RemoveShape(shape);
                    }
                }

                // Change the background color
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomRGBColor(255);
                }

                // Save the drawing to a file
                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    string path = @"C:\Users\Admin\Desktop\TestDrawing.txt";
                    myDrawing.Save(path);
                }

                // Load the drawing from a file
                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    string path = @"C:\Users\Admin\Desktop\TestDrawing.txt";
                    try
                    {
                        myDrawing.Load(path);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                }

                myDrawing.Draw();
                SplashKit.RefreshScreen();
            }
            while (!window.CloseRequested);
        }
    }

}


