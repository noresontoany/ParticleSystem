namespace ParticleSystem
{
    public partial class Form1 : Form
    {
        //List<Particle> particles = new List<Particle>();
        Emitter emitter = new Emitter(); // добавили эмиттер
        // добавляем переменные для хранения положения мыши

        public Form1()
        {
            InitializeComponent();
            
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

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
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }
    }
}
