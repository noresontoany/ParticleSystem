using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class Emitter
    {
        public List<Particle> particles = new List<Particle>();
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>(); // <<< ТАК ВОТ // тут буду хранится точки притяжения
        public int ParticlesCount = 500;

        public int MousePositionX;
        public int MousePositionY;

        public float GravitationX = 0;
        public float GravitationY = 1; // пусть гравитация будет силой один пиксель за такт, нам хватит


        public void UpdateState()
        {

            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < ParticlesCount) // пока частиц меньше 500 генерируем новые
                {

                    var particle = new ParticleColorful();
                    // ну и цвета меняем
                    particle.FromColor = Color.Yellow;
                    particle.ToColor = Color.FromArgb(0, Color.Magenta);
                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;
                    ResetParticle(particle);
                    particles.Add(particle);
                }
                else
                {
                    break; // а если частиц уже 500 штук, то ничего не генерирую
                }
            }

            foreach (var particle in particles)
            {
                particle.Life -= 1;  // не трогаем
                if (particle.Life < 0)
                {
                    ResetParticle(particle); // заменили этот блок на вызов сброса частицы 
                    //particle.Life = 20 + Particle.rand.Next(100);
                    //particle.X = MousePositionX;
                    //particle.Y = MousePositionY;

                    ///* это убираем
                    //particle.Direction = Particle.rand.Next(360);
                    //particle.Speed = 1 + Particle.rand.Next(10);
                    //*/

                    ///* ЭТО ДОБАВЛЯЮ, тут сброс состояния частицы */
                    //var direction = (double)Particle.rand.Next(360);
                    //var speed = 1 + Particle.rand.Next(10);

                    //particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
                    //particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);
                    ///* конец ЭТО ДОБАВЛЯЮ  */

                    //// это не трогаем
                    //particle.Radius = 2 + Particle.rand.Next(10);
                }

                else
                {
                    // сделаем сначала для одной точки
                    // и так считаем вектор притяжения к точке
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }
        }
        public void Render(Graphics g)
        {
            // ну тут так и быть уж сам впишу...
            // это то же самое что на форме в методе Render
            foreach (var particle in particles)
            {
                particle.Draw(g);

                //MessageBox.Show("asd");
            }

            foreach (var point in impactPoints)
            {
                point.Render(g); // это добавили
            }
        }

        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = 20 + Particle.rand.Next(100);
            particle.X = MousePositionX;
            particle.Y = MousePositionY;

            var direction = (double)Particle.rand.Next(360);
            var speed = 1 + Particle.rand.Next(10);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = 2 + Particle.rand.Next(10);
        }

    }
}
