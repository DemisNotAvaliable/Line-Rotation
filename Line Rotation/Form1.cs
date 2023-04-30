using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Line_Rotation
{
    public partial class Form1 : Form
    {
        double angle = 0;
        
        # seconds needed to complete a full rotation
        double rotTime = 2 ; # what you want

        # how many times per second the line get mooved
        double rotSteps = 360 ; # what you want

        # amount of rotation that the line has to do, see Timer_Elapsed()
        double rotAmount = Math.PI / rotSteps; 

        # every how much time increment the angle?
        double rotDelay = rotTime / rotSteps; 

        rotDelay *= 1000;  # from seconds to milliseconds
        
        Timer timer = new(rotDelay); # The Timer
        
        public Form1()
        {
            InitializeComponent();

            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            angle += rotAmount;
            pictureBox1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawLine(pictureBox1,e.Graphics, angle);
        }

        public void DrawLine(PictureBox pb, Graphics g, float angle)
        {
            double radius = 100;
            var center = new Point(pictureBox1.ClientSize.Width / 2, pictureBox1.ClientSize.Height / 2);
            // remember that sin(0)=0 and cos(0)=1
            // so if angle==0 the line is pointing up
            var end = new Point((int)(radius * Math.Sin(angle)), (int)(radius * Math.Cos(angle)));
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawLine(new Pen(Color.Red, 2f), center, end);
        }
    }
}
