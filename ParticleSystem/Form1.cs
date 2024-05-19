namespace ParticleSystem
{
    public partial class Form1 : Form
    {
        //List<Particle> particles = new List<Particle>();
        //Emitter emitter = new Emitter(); // �������� �������

        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;

        GravityPoint point1; // ������� ���� ��� ������ �����
        GravityPoint point2; // ������� ���� ��� ������ �����
        public Form1()
        {
            InitializeComponent();

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            this.emitter = new Emitter // ������ ������� � ���������� ��� � ���� emitter
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

            emitters.Add(this.emitter); // ��� ����� �������� � ������ emitters, ����� �� ���������� � ����������

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

            // ����������� ���� � ��������
            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);

            ////��������� 500 ������
            //for (var i = 0; i < 500; ++i)
            //{
            //    var particle = new Particle();
            //    // �������� ������� � ����� �����������
            //    particle.X = picDisplay.Image.Width / 2;
            //    particle.Y = picDisplay.Image.Height / 2;
            //    // �������� ������
            //    emitter.particles.Add(particle);
            //}
        }
        //private void UpdateState()
        //{
        //    foreach (var particle in particles)
        //    {
        //        particle.Life -= 1; // �������� ��������
        //                            // ���� �������� ���������
        //        if (particle.Life < 0)
        //        {
        //            // �������������� ��������
        //            particle.Life = 20 + Particle.rand.Next(100);
        //            // ��������� ������� � �����
        //            particle.X = MousePositionX;
        //            particle.Y = MousePositionY;
        //            particle.Direction = Particle.rand.Next(360);
        //            particle.Speed = 1 + Particle.rand.Next(10);
        //            particle.Radius = 2 + Particle.rand.Next(10);
        //        }
        //        else
        //        {
        //            // � ��� ��� ������ ���
        //            var directionInRadians = particle.Direction / 180 * Math.PI;
        //            particle.X += (float)(particle.Speed * Math.Cos(directionInRadians));
        //            particle.Y -= (float)(particle.Speed * Math.Sin(directionInRadians));
        //        }
        //    }


        //    for (var i = 0; i < 10; ++i)
        //    {
        //        if (particles.Count < 500) // ���� ������ ������ 500 ���������� �����
        //        {
        //            var particle = new Particle();
        //            particle.X = MousePositionX;
        //            particle.Y = MousePositionY;
        //            particles.Add(particle);
        //        }
        //        else
        //        {
        //            break; // � ���� ������ ��� 500 ����, �� ������ �� ���������
        //        }
        //    }
        //}

        ////������� ����������
        //private void Render(Graphics g)
        //{
        //    // ������� ���� ��������� ������
        //    foreach (var particle in particles)
        //    {
        //        particle.Draw(g);
        //    }
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // ������ ��� ��������� �������

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g); // � ��� ������ �������� ����� �������
            }


            picDisplay.Invalidate();

        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // � ����������� ������� ��������� ���� � ���������� ��� �������� ��������� ����
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
            lblDirection.Text = $"{tbDirection.Value}�"; // ������� ����� ��������
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
