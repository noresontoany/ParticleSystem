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
        bool MouseBounceMode = false;
        Dictionary<string, bool> people = new Dictionary<string, bool>()
        {
            {"portal", false},
            {"addgrav", false}
        };

        bool AddGravitonMode = false;
        bool PortalMode = false;
        bool BounceMode = false;

        Portal portal;
        GravityPoint point;
        BouncePoint pointBounce;
        

        GravityPoint Mousepoint;
        BouncePoint MousepointBounce;

        public Form1()
        {
            InitializeComponent();

            picDisplay.MouseWheel += picDisplay_MouseWheel;

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            this.emitter = new Emitter // создаю эмиттер и прив€зываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 3,
                SpeedMax = 5,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = 30,
                Y = 30,
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
            else if (MouseBounceMode)
            {
                MousepointBounce.X = e.X;
                MousepointBounce.Y = e.Y; 
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
            else if (BounceMode)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:

                        pointBounce = new BouncePoint
                        {
                            X = e.X,
                            Y = e.Y,
                        };

                        emitter.impactPoints.Add(pointBounce);
                        break;

                    case MouseButtons.Right:
                        BouncePoint p = null;
                        foreach (var point in emitter.impactPoints)
                        {
                            if (point.MouseIn(e) && point is BouncePoint)
                            {
                                p = (BouncePoint)point;
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
                BounceMode = false;
                PortalMode = false;

            }
            else
            {
                AddGravitonMode = false;
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
                BounceMode = false;
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
                ps = 10;
            }
            else
            {
                ps = -10;
            }

            foreach (var point in emitter.impactPoints)
            {


                if (point.MouseIn(e))
                {
                    point.Power += ps;
                }


            }
        }




        private void addBounce_Click(object sender, EventArgs e)
        {

            if (!BounceMode)
            {
                AddGravitonMode = false;
                PortalMode = false;
                BounceMode = true;

            }
            else
            {
                BounceMode = false;
            }
        }
        private void ClearBounce_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < emitter.impactPoints.Count(); i++)
            {
                if (emitter.impactPoints[i] is BouncePoint)
                {
                    emitter.impactPoints[i] = null;
                    emitter.impactPoints.Remove(emitter.impactPoints[i]);
                    i--;
                }

            }
        }







        private void MouseBou_Click(object sender, EventArgs e)
        {
            if (!MouseBounceMode)
            {
                MouseGravitoMode = false;
                MouseBounceMode = true;
                MousepointBounce = new BouncePoint
                {
                    X = picDisplay.Width,
                    Y = picDisplay.Height
                };
                emitter.impactPoints.Add(MousepointBounce);
            }
            else
            {
                MouseBounceMode = false;
                emitter.impactPoints.Remove(Mousepoint);
                MousepointBounce = null;
            }

        }
        private void MouseGravito_Click(object sender, EventArgs e)
        {
            if (!MouseGravitoMode)
            {
                MouseGravitoMode = true;
              
                MouseBounceMode = false;
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
    }
}
