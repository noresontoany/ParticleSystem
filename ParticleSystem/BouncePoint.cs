using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class BouncePoint : IImpactPoint
    {


        // а сюда по сути скопировали с минимальными правками то что было в UpdateState
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            if (r + particle.Radius <= Power / 2) // если частица оказалась внутри окружности
            {
                // Преобразуем угол направления в вектор скорости
                //if (particle.Direction < 180)
                //{
                //    particle.Direction = 180 - particle.Direction;
                //    particle.SpeedX = (float)(Math.Cos(particle.Direction / 180 * Math.PI) * 30);
                //    particle.SpeedY = -(float)(Math.Sin(particle.Direction / 180 * Math.PI) * 30);
                //}
                float nx = gX / (float)r;
                float ny = gY / (float)r;

                // Отражаем вектор скорости относительно нормали
                float dotProduct = particle.SpeedX * nx + particle.SpeedY * ny;
                particle.SpeedX -= 2 * dotProduct * nx;
                particle.SpeedY -= 2 * dotProduct * ny;

            }
        }

        public override void Render(Graphics g)
        {
            // буду рисовать окружность с диаметром равным Power
            g.DrawEllipse(
                   new Pen(Color.Blue),
                   X - Power / 2,
                   Y - Power / 2,
                   Power,
                   Power
               );
        }
    }
}
