using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCanvasTest2.Models
{
    public class Field
    {
        public readonly List<Ball> Balls = new List<Ball>();
        public float Width { get; private set; }
        public float Height { get; private set; }

        public void Resize(float width, float height) =>
            (Width, Height) = (width, height);

        public void StepForward()
        {
            foreach (Ball ball in Balls)
                ball.StepForward(Width, Height);
        }

        private float RandomVelocity(Random rand, float min, float max)
        {
            float v = min + (max - min) * (float)rand.NextDouble();
            if (rand.NextDouble() > .5)
                v *= -1;
            return v;
        }

        public void AddRandomBalls(int count = 10)
        {
            float minSpeed = .5f;
            float maxSpeed = 5;
            float radius = 10;
            Random rand = new Random();

            for (int i = 0; i < count; i++)
            {
                Balls.Add(
                    new Ball(
                        x: Width * (float)rand.NextDouble(),
                        y: Height * (float)rand.NextDouble(),
                        xVel: RandomVelocity(rand, minSpeed, maxSpeed),
                        yVel: RandomVelocity(rand, minSpeed, maxSpeed),
                        radius: radius,
                        color: string.Format("#{0:X6}", rand.Next(0xFFFFFF))
                    )
                );
            }
        }
    }
}
