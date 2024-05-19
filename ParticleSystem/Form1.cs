using System.Collections.Generic;
using System.Collections.Immutable;
using System.Windows.Forms;

namespace ParticleSystem
{
    public partial class Form1 : Form
    {
        //List<Particle> particles = new List<Particle>();
        //Emitter emitter = new Emitter(); // добавили эмиттер
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;




        
        bool MouseGravitoMode = false;
        Dictionary <string, bool> people = new Dictionary<string, bool>()
        {
            {"portal", false},
            {"addgrav", false}
        };

        bool AddGravitonMode = false;
        bool PortalMode = false;

        Portal portal;
        GravityPoint point;
        GravityPoint Mousepoint;

        public Form1()
        {
            InitializeComponent();

            picDisplay.MouseWheel += picDisplay_MouseWheel;

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            this.emitter = new Emitter // создаю эмиттер и прив€зываю его к полю emitter
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

            emitters.Add(this.emitter); // все равно добавл€ю в список emitters, чтобы он рендерилс€ и обновл€лс€

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // каждый тик обновл€ем систему

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g); // а тут теперь рендерим через эмиттер
            }


            picDisplay.Invalidate();

        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // в обработчике заносим положение мыши в переменные дл€ хранени€ положени€ мыши
            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }

            if (MouseGravitoMode)
            {
                Mousepoint.X = e.X;
                Mousepoint.Y = e.Y;
            }

        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}∞"; // добавил вывод значени€
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            
        }


       
        private bool ModeManager()
        {
            bool PortalMode = false;
            return !(PortalMode || AddGravitonMode);
        }

        //private void MouseClicks (object sender)
        //{
        //    foreach (var item in Controls)
        //    {
        //        if (item is Button && ((Button)sender).GetHashCode() != item.GetHashCode())
        //        {
        //            ((Button)item).Enabled = false;
        //        }
        //    }
        //}

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {

            if (PortalMode)
            {

                switch (e.Button)
                {
                    case MouseButtons.Left:
                        portal.X = e.X;
                        portal.Y = e.Y;
                        break;

                    case MouseButtons.Right:
                        portal.Xout = e.X;
                        portal.Yout = e.Y;
                        break;

                }
            }
            else if (AddGravitonMode)
            {

                switch (e.Button)
                {
                    case MouseButtons.Left:
                        point = new GravityPoint
                        {
                            X = e.X,
                            Y = e.Y,
                        };

                        emitter.impactPoints.Add(point);
                        break;

                    case MouseButtons.Right:
                        GravityPoint p = null;
                        foreach (var point in emitter.impactPoints)
                        {
                            if (point.MouseIn(e) && point is GravityPoint)
                            {
                                p = (GravityPoint)point;

                            }
                        }
                        emitter.impactPoints.Remove(p);
                        break;

                }
                
            }

        }

        private void addGraviton_Click(object sender, EventArgs e)
        {

            if (!AddGravitonMode)
            {

                AddGravitonMode = true;
                PortalMode = false;

            }
            else
            {
                AddGravitonMode = false;
            }
        }

        private void MouseGravito_Click(object sender, EventArgs e)
        {
            if (!MouseGravitoMode)
            {
                MouseGravitoMode = true;
                Mousepoint = new GravityPoint
                {
                    X = picDisplay.Width,
                    Y = picDisplay.Height
                };
                emitter.impactPoints.Add(Mousepoint);
            }
            else
            {
                MouseGravitoMode = false;
                emitter.impactPoints.Remove(Mousepoint);
                Mousepoint = null;

            }
        }

        private void ClearGravitos_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < emitter.impactPoints.Count(); i++)
            {
                if (emitter.impactPoints[i] is GravityPoint)
                {
                    emitter.impactPoints[i] = null;
                    emitter.impactPoints.Remove(emitter.impactPoints[i]);
                    i--;
                }

            }


        }

        private void portalClear_Click(object sender, EventArgs e)
        {
            emitter.impactPoints.Remove(portal);
            portal = null;
        }
        private void portalBtn_Click(object sender, EventArgs e)
        {
            if (!PortalMode)
            {

                PortalMode = true;
                AddGravitonMode = false;
                portal = new Portal
                {
                    X = 100,
                    Y = 100,
                    Xout = 300,
                    Yout = 300
                };
                emitter.impactPoints.Add(portal);
            }
            else
            {
                PortalMode = false;
            }
        }

        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            int ps = 0;
            if (e.Delta > 0)
            {
                ps =  10;
            }
            else
            {
                ps = - 10;
            }

            foreach (var point in emitter.impactPoints)
            {


                if (point.MouseIn(e))
                {
                    point.Power += ps;
                }
                  
             
            }
        }
    }
}
