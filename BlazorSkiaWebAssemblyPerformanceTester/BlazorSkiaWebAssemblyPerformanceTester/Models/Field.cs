namespace BlazorSkiaWebAssemblyPerformanceTester.Models
{
    public class Field
    {
        readonly Random _rand = new();
        public readonly List<Ball> Balls = new();

        public float Width { get; private set; }
        public float Height { get; private set; }

        public int Count => Balls.Count;

        public void Resize(float width, float height) =>
            (Width, Height) = (width, height);

        public void StepForward()
        {
            foreach (var ball in Balls)
                ball.StepForward(Width, Height);
        }

        private static float RandomVelocity(Random rand, float min, float max)
        {
            var v = min + (max - min) * (float)rand.NextDouble();
            if (rand.NextDouble() > .5)
                v *= -1;
            return v;
        }

        public void AddRandomBalls(int count = 10)
        {
            var minSpeed = .5f;
            float maxSpeed = 5;
            float radius = 10;

            for (var i = 0; i < count; i++)
            {
                var ball = new Ball(
                    x: Width * (float)_rand.NextDouble(),
                    y: Height * (float)_rand.NextDouble(),
                    xVel: RandomVelocity(_rand, minSpeed, maxSpeed),
                    yVel: RandomVelocity(_rand, minSpeed, maxSpeed),
                    radius: radius,
                    color: $"#{_rand.Next(0xFFFFFF):X6}");
                Balls.Add(ball);
            }
        }

        public void RemoveRandomBalls(int count)
        {
            for (var i = 0; i < count && Balls.Count > 0; i++) 
                Balls.RemoveAt(Balls.Count - 1);
        }
    }
}
