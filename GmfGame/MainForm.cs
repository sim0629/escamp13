using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace GmfGame
{
    public partial class MainForm : Form
    {
        private const float updateInterval = 0.03f;

        private float totalElapsedSeconds = 0f;
        private GameCore.World world;

        private bool isPlaying = false;

        public MainForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        // elapsedSeconds : 전 프레임에서 지난 시간
        public void UpdateWorld(float elapsedSeconds)
        {
            if (!isPlaying)
            {
                if (GmfKey.IsKeyPressed(Keys.Enter))
                {
                    isPlaying = true;
                    world = new GameCore.World();
                }
                else
                {
                    return;
                }
            }

            if ((int)(totalElapsedSeconds / updateInterval)
                != (int)((totalElapsedSeconds + elapsedSeconds) / updateInterval))
            {
                isPlaying = world.Update();
            }
            totalElapsedSeconds += elapsedSeconds;
        }

        private void RenderWorld(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);
            if (world != null) world.Draw(g);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            GmfKey.SetKeyPressed(e.KeyCode, true);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            GmfKey.SetKeyPressed(e.KeyCode, false);
        }
    }
}
