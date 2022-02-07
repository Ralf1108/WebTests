namespace BlazorSkiaWebAssemblyPerformanceTester.Models
{
    public class Ball
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float XVel { get; private set; }
        public float YVel { get; private set; }
        public float R { get; private set; }
        public string Color { get; private set; }

        public Ball(float x, float y, float xVel, float yVel, float radius, string color)
        {
            (X, Y, XVel, YVel, R, Color) = (x, y, xVel, yVel, radius, color);
        }

        public void StepForward(float width, float height)
        {
            X += XVel;
            Y += YVel;
            if (X < 0 || X > width)
                XVel *= -1;
            if (Y < 0 || Y > height)
                YVel *= -1;

            if (X < 0)
                X += 0 - X;
            else if (X > width)
                X -= X - width;

            if (Y < 0)
                Y += 0 - Y;
            if (Y > height)
                Y -= Y - height;
        }
    }
}
