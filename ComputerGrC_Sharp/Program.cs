using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
namespace ComputerGrC_Sharp
{
    class Program
    {
        static void DrawLine(int x1, int y1, int x2, int y2, RenderWindow window)
        {
            Vertex[] line = new Vertex[]
            {
            new Vertex(new Vector2f(x1, y1)),
            new Vertex(new Vector2f(x2, y2))
            };

            window.Draw(line, PrimitiveType.Lines);
        }

        static void Square(int n, int x0, int y0, int a, double startAngle, double delta, RenderWindow window)
        {
            if (n == 0) {return;}
           
            int x1, y1, x2, y2, x3, y3, x5, y5;
            double rigthLength, leftLength;

            rigthLength = a * Math.Sin(delta);
            leftLength = a * Math.Cos(delta);
            
            x1 = (int)(x0 + a * Math.Cos(startAngle)); 
            y1 = (int)(y0 - a * Math.Sin(startAngle));
            
            x2 = (int)(x1 - a * Math.Sin(startAngle)); 
            y2 = (int)(y1 - a * Math.Cos(startAngle));
            
            x3 = (int)(x0 - a * Math.Sin(startAngle));
            y3 = (int)(y0 - a * Math.Cos(startAngle));

            x5 = (int)(x3 + leftLength * Math.Cos(startAngle + delta)); 
            y5 = (int)(y3 - leftLength * Math.Sin(startAngle + delta));

            DrawLine(x0, y0, x1, y1, window);
            DrawLine(x1, y1, x2, y2, window);
            DrawLine(x2, y2, x3, y3, window);
            DrawLine(x3, y3, x0, y0, window);
            n--;

            Square(n, x3, y3, (int)leftLength, startAngle + delta, delta, window);
            Square(n, x5, y5, (int)rigthLength, startAngle + delta - Math.PI / 2, delta, window);
        }

        static void Main()
        {
            RenderWindow window = new RenderWindow(new VideoMode(1000, 1000), "SFML Works!");
            int n = 15, x0 = 350, y0 = 700, a = 100;
            double f = Math.PI / 3, delta = Math.PI / 3;

            while (window.IsOpen)
            {
                window.DispatchEvents(); // Обработка событий
                window.Clear(new Color(0, 0, 0));
                Square(n, x0, y0, a, f, delta, window);
                window.Display();
            }
        }
    }
}
