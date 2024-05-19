namespace ParticleSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            picDisplay = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            tbDirection = new TrackBar();
            lblDirection = new Label();
            tbGraviton = new TrackBar();
            tbGraviton2 = new TrackBar();
            portalBtn = new Button();
            addGraviton = new Button();
            MouseGravito = new Button();
            ClearGravitos = new Button();
            portalClear = new Button();
            addBounce = new Button();
            ClearBounce = new Button();
            MouseBou = new Button();
            SnowOne = new Button();
            ((System.ComponentModel.ISupportInitialize)picDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton2).BeginInit();
            SuspendLayout();
            // 
            // picDisplay
            // 
            picDisplay.Location = new Point(22, 22);
            picDisplay.Margin = new Padding(2);
            picDisplay.Name = "picDisplay";
            picDisplay.Size = new Size(1083, 436);
            picDisplay.TabIndex = 0;
            picDisplay.TabStop = false;
            picDisplay.MouseClick += picDisplay_MouseClick;
            picDisplay.MouseMove += picDisplay_MouseMove;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 40;
            timer1.Tick += timer1_Tick;
            // 
            // tbDirection
            // 
            tbDirection.Location = new Point(22, 484);
            tbDirection.Maximum = 359;
            tbDirection.Name = "tbDirection";
            tbDirection.Size = new Size(307, 45);
            tbDirection.TabIndex = 1;
            tbDirection.Scroll += tbDirection_Scroll;
            // 
            // lblDirection
            // 
            lblDirection.AutoSize = true;
            lblDirection.Location = new Point(336, 487);
            lblDirection.Name = "lblDirection";
            lblDirection.Size = new Size(12, 15);
            lblDirection.TabIndex = 2;
            lblDirection.Text = "°";
            // 
            // tbGraviton
            // 
            tbGraviton.Location = new Point(610, 482);
            tbGraviton.Maximum = 100;
            tbGraviton.Name = "tbGraviton";
            tbGraviton.Size = new Size(121, 45);
            tbGraviton.TabIndex = 3;
            tbGraviton.Scroll += tbGraviton_Scroll;
            // 
            // tbGraviton2
            // 
            tbGraviton2.Location = new Point(441, 482);
            tbGraviton2.Maximum = 100;
            tbGraviton2.Name = "tbGraviton2";
            tbGraviton2.Size = new Size(104, 45);
            tbGraviton2.TabIndex = 4;
            // 
            // portalBtn
            // 
            portalBtn.ForeColor = SystemColors.ActiveCaptionText;
            portalBtn.Location = new Point(1127, 33);
            portalBtn.Name = "portalBtn";
            portalBtn.Size = new Size(75, 23);
            portalBtn.TabIndex = 5;
            portalBtn.Text = "portal";
            portalBtn.UseVisualStyleBackColor = true;
            portalBtn.Click += portalBtn_Click;
            // 
            // addGraviton
            // 
            addGraviton.Location = new Point(1127, 92);
            addGraviton.Name = "addGraviton";
            addGraviton.Size = new Size(75, 23);
            addGraviton.TabIndex = 6;
            addGraviton.Text = "AddGraviton";
            addGraviton.UseVisualStyleBackColor = true;
            addGraviton.Click += addGraviton_Click;
            // 
            // MouseGravito
            // 
            MouseGravito.Location = new Point(1319, 92);
            MouseGravito.Name = "MouseGravito";
            MouseGravito.Size = new Size(75, 23);
            MouseGravito.TabIndex = 7;
            MouseGravito.Text = "MouseGravito";
            MouseGravito.UseVisualStyleBackColor = true;
            MouseGravito.Click += MouseGravito_Click;
            // 
            // ClearGravitos
            // 
            ClearGravitos.Location = new Point(1225, 92);
            ClearGravitos.Name = "ClearGravitos";
            ClearGravitos.Size = new Size(75, 23);
            ClearGravitos.TabIndex = 8;
            ClearGravitos.Text = "ClearGravitos";
            ClearGravitos.UseVisualStyleBackColor = true;
            ClearGravitos.Click += ClearGravitos_Click;
            // 
            // portalClear
            // 
            portalClear.Location = new Point(1225, 33);
            portalClear.Name = "portalClear";
            portalClear.Size = new Size(75, 23);
            portalClear.TabIndex = 9;
            portalClear.Text = "portalClear";
            portalClear.UseVisualStyleBackColor = true;
            portalClear.Click += portalClear_Click;
            // 
            // addBounce
            // 
            addBounce.Location = new Point(1127, 147);
            addBounce.Name = "addBounce";
            addBounce.Size = new Size(75, 23);
            addBounce.TabIndex = 10;
            addBounce.Text = "addBounce";
            addBounce.UseVisualStyleBackColor = true;
            addBounce.Click += addBounce_Click;
            // 
            // ClearBounce
            // 
            ClearBounce.Location = new Point(1225, 147);
            ClearBounce.Name = "ClearBounce";
            ClearBounce.Size = new Size(75, 23);
            ClearBounce.TabIndex = 11;
            ClearBounce.Text = "ClearBounce";
            ClearBounce.UseVisualStyleBackColor = true;
            ClearBounce.Click += ClearBounce_Click;
            // 
            // MouseBou
            // 
            MouseBou.Location = new Point(1319, 147);
            MouseBou.Name = "MouseBou";
            MouseBou.Size = new Size(75, 23);
            MouseBou.TabIndex = 12;
            MouseBou.Text = "MouseBou";
            MouseBou.UseVisualStyleBackColor = true;
            MouseBou.Click += MouseBou_Click;
            // 
            // SnowOne
            // 
            SnowOne.Location = new Point(1127, 435);
            SnowOne.Name = "SnowOne";
            SnowOne.Size = new Size(75, 23);
            SnowOne.TabIndex = 13;
            SnowOne.Text = "Snow";
            SnowOne.UseVisualStyleBackColor = true;
            SnowOne.Click += SnowOne_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1429, 541);
            Controls.Add(SnowOne);
            Controls.Add(MouseBou);
            Controls.Add(ClearBounce);
            Controls.Add(addBounce);
            Controls.Add(portalClear);
            Controls.Add(ClearGravitos);
            Controls.Add(MouseGravito);
            Controls.Add(addGraviton);
            Controls.Add(portalBtn);
            Controls.Add(tbGraviton2);
            Controls.Add(tbGraviton);
            Controls.Add(lblDirection);
            Controls.Add(tbDirection);
            Controls.Add(picDisplay);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picDisplay).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private TrackBar tbDirection;
        private Label lblDirection;
        private TrackBar tbGraviton;
        private TrackBar tbGraviton2;
        private Button portalBtn;
        private Button addGraviton;
        private Button MouseGravito;
        private Button ClearGravitos;
        private Button portalClear;
        private Button addBounce;
        private Button ClearBounce;
        private Button MouseBou;
        private Button SnowOne;
    }
}
