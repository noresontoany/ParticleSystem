using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class ColorPoint : IImpactPoint
    {


        
        Color clr;
        // а сюда по сути скопировали с минимальными правками то что было в UpdateState
        public ColorPoint(Color clr)
        {
            this.clr = clr;
        }
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            if (r + particle.Radius < Power / 2) // если частица оказалось внутри окружности
            {

                //particle.clr = clr;
                particle.FromColor = clr;
                particle.ToColor = clr;

            }
        }
        public override void Render(Graphics g)
        {
            // буду рисовать окружность с диаметром равным Power
            
             
            g.DrawEllipse(
                   new Pen(clr),
                   X - Power / 2,
                   Y - Power / 2,
                   Power,
                   Power
               );
           
        }
    }
}
