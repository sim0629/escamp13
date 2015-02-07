using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace GmfGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Directory.Exists("Image"))
            {
                Directory.SetCurrentDirectory("../../");
                if (!Directory.Exists("Image"))
                {
                    MessageBox.Show("Image 폴더가 없습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm form = new MainForm();
            form.ClientSize = new Size(GameCore.Constant.WIDTH, GameCore.Constant.HEIGHT);
            form.Show();

            DateTime updatedTime = DateTime.Now;
            while (form.Created)
            {
                DateTime neoUpdatedTime = DateTime.Now;
                form.UpdateWorld((float)(neoUpdatedTime - updatedTime).TotalSeconds);
                updatedTime = DateTime.Now;

                form.Invalidate();

                Application.DoEvents();
            }
        }
    }
}
