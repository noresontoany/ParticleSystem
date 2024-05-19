using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class Portal : IImpactPoint
    {
        

        public int Xout;
        public int Yout;

        // а сюда по сути скопировали с минимальными правками то что было в UpdateState
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            if (r + particle.Radius < Power / 2) // если частица оказалось внутри окружности
            {
                // то притягиваем ее
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                particle.X = Xout;
                particle.Y = Yout;
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

            g.DrawEllipse(
                   new Pen(Color.Blue),
                   Xout - Power / 2,
                   Yout - Power / 2,
                   Power,
                   Power
               );
            g.DrawLine(
                   new Pen(Color.Green),
                   Xout ,
                   Yout ,
                   X,
                   Y
               );
        }

        public override bool MouseIn(MouseEventArgs e)
        {
            float gX = X - e.X;
            float gY = Y - e.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы

            if (r + 2 < Power / 2) // если частица оказалось внутри окружности
            {
                return true;
            }

            gX = Xout - e.X;
            gY = Yout - e.Y;

            r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы

            if (r + 2 < Power / 2) // если частица оказалось внутри окружности
            {
                return true;
            }

            return false;
        }
    }
}
