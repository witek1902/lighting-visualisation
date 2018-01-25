namespace LightingVisualization
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using Model;
    using System.Windows.Forms;
    using Logic;

    public partial class LightingVisualization : Form
    {
        private readonly PhongOperator phongOperator;
        private readonly Surface surface;
        private readonly Bitmap shadedBitmap;

        public LightingVisualization()
        {
            InitializeComponent();
            shadedBitmap = new Bitmap(500,500, PixelFormat.Format24bppRgb);

            Graphics g = Graphics.FromImage(shadedBitmap);
            g.Clear(Color.Black);
            g.FillEllipse(new SolidBrush(Color.SaddleBrown), 100, 100, 300, 300);
            GraphicIcon.Image = shadedBitmap;

            phongOperator = new PhongOperator();
            surface = new Surface
            {
                Ks = 0.25,
                Kd = 0.75,
                N = 5
            };
        }

        private void LightingVisualization_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            KeyDown += LightingVisualization_KeyDown;
        }

        private void SetNewIcon()
        {
            GraphicIcon.Image = phongOperator.PhongAlgorithm(shadedBitmap, surface);
        }

        private void LightingVisualization_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    phongOperator.MoveRight();
                    break;
                case Keys.A:
                    phongOperator.Up();
                    break;
                case Keys.S:
                    phongOperator.MoveLeft();
                    break;
                case Keys.D:
                    phongOperator.Down();
                    break;
                case Keys.O:
                    phongOperator.Forward();
                    break;
                case Keys.L:
                    phongOperator.Backward();
                    break;
            }
            SetNewIcon();
        }

        private void Mirror_CheckedChanged(object sender, EventArgs e)
        {
            //Symulujemy powierzchnie lustra (metaliczna, lustrzana)
            surface.Ks = 0.25;
            surface.Kd = 0.75;
            surface.N = 5;
            SetNewIcon();
        }

        private void Intermediate_CheckedChanged(object sender, EventArgs e)
        {
            //Symulujemy powierzchnie przejściową
            surface.Ks = 0.5;
            surface.Kd = 0.5;
            surface.N = 10;
            SetNewIcon();
        }

        private void Wood_CheckedChanged(object sender, EventArgs e)
        {
            //Symulujemy powierzchnie drewna (matowa)
            surface.Ks = 0.75;
            surface.Kd = 0.25;
            surface.N = 100;
            SetNewIcon();
        }
    }
}
