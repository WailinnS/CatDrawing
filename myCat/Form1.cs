using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myCat
{
    public partial class Form1 : Form
    {
        Graphics gfx;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            gfx = CreateGraphics();

            this.Text = "Cat Drawing";

            //makes form not resizeable.
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            this.MinimizeBox = false;

         
           
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

           //for debuging
           // Point pos = this.PointToClient(Cursor.Position);
           // this.Text = $"X: {pos.X} Y: {pos.Y}";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            //backround
            gfx.FillRectangle(Brushes.SkyBlue, 0, 0, ClientSize.Width, ClientSize.Height / 2);
            gfx.FillRectangle(Brushes.Green, 0, ClientSize.Height/2, ClientSize.Width, ClientSize.Height);
            //clouds
            gfx.FillEllipse(Brushes.Snow, 0, 0, 70, 50);
            gfx.FillEllipse(Brushes.Snow, 40, 0, 70, 50);
            gfx.FillEllipse(Brushes.Snow, 20, 20, 70, 50);
            gfx.FillEllipse(Brushes.Snow, 335, 50, 70, 50);
            gfx.FillEllipse(Brushes.Snow, 375, 50, 70, 50);
            gfx.FillEllipse(Brushes.Snow, 345, 70, 70, 50);

            //head & face
            gfx.FillEllipse(Brushes.SteelBlue, 175, 75, 100, 100);
            gfx.DrawArc(Pens.Black, 195, 111, 25, 25, 220, 100);
            gfx.DrawArc(Pens.Black, 230, 111, 25, 25, 220, 100);
            Point[] face =
            {
                new Point(224,127),
                new Point(220,123),
                new Point(228,123)
            };
            gfx.FillPolygon(Brushes.Pink, face);
            //mouth
            gfx.DrawArc(Pens.Black, 210, 125, 15, 15, 0, 150);
            gfx.DrawArc(Pens.Black, 225, 125, 15, 15, 0, 150);

            //whiskers
            //using archs and points
            gfx.DrawArc(Pens.Black, 260, 120, 40, 15, 180, 180);
            gfx.DrawArc(Pens.Black, 260, 130, 35, 15, 180, 190);

            //using a ellipse( rectangle outline ) to only draw the arcs from that shape.
            Rectangle topWhisk = new Rectangle(165, 140, 50, 30);
            Rectangle botWhisk = new Rectangle(170, 150, 50, 30);
            gfx.DrawArc(Pens.Black, topWhisk, 180, 90);
            gfx.DrawArc(Pens.Black, botWhisk, 180, 90);



            //right ear
            GraphicsPath outsideRight = new GraphicsPath();
            GraphicsPath insideRight = new GraphicsPath();
            Point[] rightFur =
            {
                new Point(246,80),
                new Point(265,50),
                new Point(281,31),
                new Point(261,90)
            };
            Point[] rightNoFur =
            {
                new Point(261,90),
                new Point(281,31),
                new Point(272,108)
            };
            outsideRight.AddPolygon(rightFur);
            insideRight.AddPolygon(rightNoFur);
            gfx.FillPath(Brushes.SteelBlue, outsideRight);
            gfx.FillPath(Brushes.Pink, insideRight);

            //Left ear
            GraphicsPath outsideLeft = new GraphicsPath();
            GraphicsPath insideLeft = new GraphicsPath();
            Point[] leftFur =
            {
                new Point(185,95),
                new Point(172,91),
                new Point(120,83),
                new Point(179,110)
            };
            Point[] leftNoFur =
            {
                new Point(120,83),
                new Point(178,110),
                new Point(179,111),
                new Point(176,136),
                new Point(164,113)
            };
            outsideLeft.AddPolygon(leftFur);
            insideLeft.AddPolygon(leftNoFur);
            gfx.FillPath(Brushes.SteelBlue, outsideLeft);
            gfx.FillPath(Brushes.Pink, insideLeft);
            GraphicsPath body = new GraphicsPath();


            //body outline
            Point[] mainBody =
            {
                new Point(255,166),
                new Point(260,175),
                new Point(280,190),
                new Point(290,195),
                new Point(311,210),
                new Point(320,250),
                new Point(310,273),
                new Point(310,273),
                new Point(270,273),
                new Point(260,250),
                new Point(230,240),
                new Point(225,230),//start of left side
                new Point(225,273),
                new Point(225,273),
                new Point(200,273),
                new Point(185,270),
                new Point(202,250),
                new Point(202,168)

            };


            body.AddCurve(mainBody);
            gfx.FillPath(Brushes.SteelBlue, body);

            //collar
            Point[] collar =
            {
                new Point(203,170),
                new Point(230,178),
                new Point(256,170)
            };

            gfx.DrawCurve(new Pen(Brushes.DarkSlateBlue, 5.0f), collar);
            gfx.FillEllipse(Brushes.Gold, 220, 175, 10, 10);

            //tail
            Point[] tail =
            {
                new Point(315,248),
                new Point(340,240),
                new Point(370,248),
                new Point(390,240)
            };

            gfx.DrawCurve(new Pen(Color.SteelBlue, 10.0f), tail);
            gfx.DrawArc(new Pen(Color.SteelBlue, 10.0f), 385, 235, 5, 5, 0, 90); //makes the round end of the tail.

            //leg outline
            gfx.DrawArc(Pens.Black, 280, 230, 40, 40, 200, 120);

            Point[] rightLeg =
            {
                new Point(281,243),
                new Point(281,260),
                new Point(277,258),
                new Point(274,257),
                new Point(270,258),
                new Point(265,260)
            };

            gfx.DrawCurve(Pens.Black, rightLeg, 0.6f);

            Point[] rightpaw =
            {
                new Point(250,215),
                new Point(250,225),
                new Point(240,227),
                new Point(230,227),
                new Point(226,229),
                new Point(230,240),
                new Point(240,243),
                new Point(260,242)

            };

            gfx.DrawCurve(Pens.Black, rightpaw, 0.6f);

            //yarn
            gfx.FillEllipse(Brushes.Red, 225, 243, 40, 40);
            Point[] yarnTrail =
            {
                new Point(234,279),
                new Point(215,290),
                new Point(245,295),
                new Point(230,320)
            };
            gfx.DrawCurve(new Pen(Color.Red, 5.0f), yarnTrail);



        }
    }
}
