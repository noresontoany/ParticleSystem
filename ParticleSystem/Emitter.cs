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

        public int X; // координата X центра эмиттера, будем ее использовать вместо MousePositionX
        public int Y; // соответствующая координата Y 

        public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 360; // разброс частиц относительно Direction

        public int SpeedMin = 1; // начальная минимальная скорость движения частицы
        public int SpeedMax = 10; // начальная максимальная скорость движения частицы

        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы

        public int LifeMin = 20; // минимальное время жизни частицы
        public int LifeMax = 100; // максимальное время жизни частицы
        public int ParticlesPerTick = 1; // добавил новое поле

        public Color ColorFrom = Color.White; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Black); // конечный цвет частиц
        public void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick; // фиксируем счетчик сколько частиц нам создавать за тик
            foreach (var particle in particles)
            {
                
                if (particle.Life <= 0)
                {
                    //ResetParticle(particle); // заменили этот блок на вызов сброса частицы 
                    if (particlesToCreate > 0)
                    {
                        /* у нас как сброс частицы равносилен созданию частицы */
                        particlesToCreate -= 1; // поэтому уменьшаем счётчик созданных частиц на 1
                        ResetParticle(particle);
                    }
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

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;

                    particle.Life -= 1;
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    
                }
            }

            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
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
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            particle.FromColor = Color.White; // начальный цвет частицы
            particle.ToColor = Color.FromArgb(0, Color.Black); // конечный цвет частиц

        var direction = Direction
                + (double)Particle.rand.Next(Spreading)
                - Spreading / 2;

            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
        }

        public virtual Particle CreateParticle()
        {
            //var particle = new ParticleColorful();
            var particle = new Particle();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }


    }
}
