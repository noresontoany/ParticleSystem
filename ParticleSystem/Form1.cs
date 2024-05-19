namespace ParticleSystem
{
    public partial class Form1 : Form
    {
        //List<Particle> particles = new List<Particle>();
        //Emitter emitter = new Emitter(); // добавили эмиттер

        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;

        GravityPoint point1; // добавил поле под первую точку
        GravityPoint point2; // добавил поле под вторую точку
        public Form1()
        {
            InitializeComponent();

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitters.Add(this.emitter); // все равно добавляю в список emitters, чтобы он рендерился и обновлялся

            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
            };
            point2 = new GravityPoint
            {
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2,
            };

            // привязываем поля к эмиттеру
            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);

            ////генерирую 500 частиц
            //for (var i = 0; i < 500; ++i)
            //{
            //    var particle = new Particle();
            //    // переношу частицы в центр изображения
            //    particle.X = picDisplay.Image.Width / 2;
            //    particle.Y = picDisplay.Image.Height / 2;
            //    // добавляю список
            //    emitter.particles.Add(particle);
            //}
        }
        //private void UpdateState()
        //{
        //    foreach (var particle in particles)
        //    {
        //        particle.Life -= 1; // уменьшаю здоровье
        //                            // если здоровье кончилось
        //        if (particle.Life < 0)
        //        {
        //            // восстанавливаю здоровье
        //            particle.Life = 20 + Particle.rand.Next(100);
        //            // перемещаю частицу в центр
        //            particle.X = MousePositionX;
        //            particle.Y = MousePositionY;
        //            particle.Direction = Particle.rand.Next(360);
        //            particle.Speed = 1 + Particle.rand.Next(10);
        //            particle.Radius = 2 + Particle.rand.Next(10);
        //        }
        //        else
        //        {
        //            // а это наш старый код
        //            var directionInRadians = particle.Direction / 180 * Math.PI;
        //            particle.X += (float)(particle.Speed * Math.Cos(directionInRadians));
        //            particle.Y -= (float)(particle.Speed * Math.Sin(directionInRadians));
        //        }
        //    }


        //    for (var i = 0; i < 10; ++i)
        //    {
        //        if (particles.Count < 500) // пока частиц меньше 500 генерируем новые
        //        {
        //            var particle = new Particle();
        //            particle.X = MousePositionX;
        //            particle.Y = MousePositionY;
        //            particles.Add(particle);
        //        }
        //        else
        //        {
        //            break; // а если частиц уже 500 штук, то ничего не генерирую
        //        }
        //    }
        //}

        ////функция рендеринга
        //private void Render(Graphics g)
        //{
        //    // утащили сюда отрисовку частиц
        //    foreach (var particle in particles)
        //    {
        //        particle.Draw(g);
        //    }
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // каждый тик обновляем систему

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g); // а тут теперь рендерим через эмиттер
            }


            picDisplay.Invalidate();

        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // в обработчике заносим положение мыши в переменные для хранения положения мыши
            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }


            point2.X = e.X;
            point2.Y = e.Y;
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}°"; // добавил вывод значения
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGraviton.Value;
        }

        private void tbGraviton2_Scroll(object sender, EventArgs e)
        {
            point2.Power = tbGraviton2.Value;
        }
    }
}
