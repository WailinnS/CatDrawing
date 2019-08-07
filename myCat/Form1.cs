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
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            Point pos = this.PointToClient(Cursor.Position);
            this.Text = $"X: {pos.X} Y: {pos.Y}";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            //head & face
            gfx.FillEllipse(Brushes.SteelBlue, 175, 75, 100, 100);
            gfx.DrawArc(Pens.Black, 195, 111, 25, 25, 220, 100);
            gfx.DrawArc(Pens.Black, 230, 111, 25, 25, 220, 100);
            Point[] pnt =
            {
                new Point(224,127),
                new Point(220,123),
                new Point(228,123)
            };
            gfx.FillPolygon(Brushes.Pink, pnt);

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




            Point[] tail =
            {
                new Point(315,248),
                new Point(340,240),
                new Point(370,248),
                new Point(390,240)
            };

            body.AddCurve(mainBody);
   
            gfx.FillPath(Brushes.SteelBlue, body);
         
            gfx.DrawCurve(new Pen(Color.SteelBlue,10.0f),tail);
            gfx.DrawArc(new Pen(Color.SteelBlue, 10.0f), 385, 235,5, 5, 0 , 90);

            //leg outline
            //gfx.DrawEllipse(Pens.RoyalBlue, 280, 230, 40, 40);
            gfx.DrawArc(Pens.Black, 280, 230, 40, 40, 200, 120);
            gfx.FillEllipse(Brushes.Red, 225, 241, 40, 40); //ball

        }
    }
}
