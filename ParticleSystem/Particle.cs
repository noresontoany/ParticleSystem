using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class Particle
    {
        public int Radius; // радиус частицы
        public float X; // X координата положения частицы в пространстве
        public float Y; // Y координата положения частицы в пространстве
        public float Life; // запас здоровья частицы

        public float Direction; // направление движения
        public float Speed; // скорость перемещения

        public float SpeedX; 
        public float SpeedY;


        public Color FromColor = Color.Green;
        public Color ToColor = Color.HotPink;

       

        // добавили генератор случайных чисел
        public static Random rand = new Random();

        // конструктор по умолчанию будет создавать кастомную частицу
        public Particle()
        {
            // я не трогаю координаты X, Y потому что хочу, чтобы все частицы возникали из одного места
                
            var direction = (double)rand.Next(360);
            var speed = 1 + rand.Next(10);

            // рассчитываем вектор скорости
            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            // а это не трогаем
            Radius = 2 + rand.Next(10);
            Life = 20 + rand.Next(100);
        }

        public virtual void Draw(Graphics g)
        {
            // рассчитываем коэффициент прозрачности по шкале от 0 до 1.0
            float k = Math.Min(1f, Life / 100);



            // так как k уменьшается от 1 до 0, то порядок цветов обратный
            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }

        public Color MixColor(Color color1, Color color2, float k)
        {
                return Color.FromArgb(
                    (int)(color2.A * k + color1.A * (1 - k)),
                    (int)(color2.R * k + color1.R * (1 - k)),
                    (int)(color2.G * k + color1.G * (1 - k)),
                    (int)(color2.B * k + color1.B * (1 - k))
                );
    
        }


    }

    //public class ParticleColorful : Particle
    //{
    //    // два новых поля под цвет начальный и конечный

    //    public static bool p = true;
    //    // для смеси цветов
    //    public Color MixColor(Color color1, Color color2, float k)
    //    {
            
    //        if (p)
    //        {
    //            return Color.FromArgb(
    //                (int)(color2.A * k + color1.A * (1 - k)),
    //                (int)(color2.R * k + color1.R * (1 - k)),
    //                (int)(color2.G * k + color1.G * (1 - k)),
    //                (int)(color2.B * k + color1.B * (1 - k))
    //            );
    //        }
    //        return Color.Gray;
    //    }

    //    // ну и отрисовку перепишем
    //    public override void Draw(Graphics g)
    //    {

            
    //        float k = Math.Min(1f, Life / 100);



    //        // так как k уменьшается от 1 до 0, то порядок цветов обратный
    //        var color = MixColor(Color.HotPink, Color.Black, k);
    //        var b = new SolidBrush(color);

    //        g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

    //        b.Dispose();
    //    }
    //}
}
